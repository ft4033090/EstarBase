using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EstarDXBase.Infrastructure.Tool.Entity
{
    /// <summary>
    /// 可持久到数据库的领域模型的基类。
    /// </summary>
    [Serializable]
    public abstract class EntityBase<TKey>
    {

   
        #region 构造函数

        /// <summary>
        /// 数据实体基类
        /// </summary>
        protected EntityBase()
        {
            //创建默认Guid
            if (typeof(TKey) == typeof(Guid))
            {
                Id = CombHelper.NewComb().CastTo<TKey>();
            }
            IsDeleted = false;
        }

        #endregion

        #region 属性

        [Key]
        public TKey Id { get; set; }

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool? IsDeleted { get; set; }

        #endregion
    }
}