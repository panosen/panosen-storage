using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panosen.Storage.Qiniu
{
    /// <summary>
    /// 七牛云配置
    /// </summary>
    public class QiniuConfig
    {
        /// <summary>
        /// AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Bucket
        /// </summary>
        public string Bucket { get; set; }
    }
}
