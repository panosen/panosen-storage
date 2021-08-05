using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using System;

namespace Panosen.Storage.Qiniu
{
    /// <summary>
    /// 上传文件到七牛云
    /// </summary>
    public class QiniuStorage
    {
        private readonly QiniuConfig qiniuConfig;

        /// <summary>
        /// 上传文件到七牛云
        /// </summary>
        public QiniuStorage(QiniuConfig qiniuConfig)
        {
            this.qiniuConfig = qiniuConfig;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        public void Save(string key, byte[] bytes)
        {
            Mac mac = new Mac(qiniuConfig.AccessKey, qiniuConfig.SecretKey);

            //上传策略
            PutPolicy putPolicy = new PutPolicy();

            //设置要上传的目标空间
            putPolicy.Scope = string.Concat(qiniuConfig.Bucket, ":", key);

            //上传策略的过期时间(单位: 秒)
            putPolicy.SetExpires(30);

            //上传文件token
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());

            Config config = new Config();
            config.Zone = Zone.ZONE_CN_South;
            config.UseHttps = true;
            config.UseCdnDomains = true;
            config.ChunkSize = ChunkUnit.U512K;
            FormUploader target = new FormUploader(config);
            HttpResult result = target.UploadData(bytes, key, token, null);
        }
    }
}
