using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeduInfo.Models
{
    public class FindBusinesses
    {
        [Key]
        public int ID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        /// <summary>
        /// 偏移类型，0:未偏移，1:高德坐标系偏移，2:图吧坐标系偏移，如不传入，默认值为0
        /// </summary>
        public int Offset_type { get; set; }
        /// <summary>
        /// 搜索半径，单位为米，最小值1，最大值5000，如不传入默认为1000
        /// </summary>
        public int Radius { get; set; }
        public string City { get; set; }
        /// <summary>
        /// 城市区域名，可选范围见相关API返回结果（不含返回结果中包括的城市名称信息），如传入城市区域名，则城市名称必须传入
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 分类名，可选范围见相关API返回结果；支持同时输入多个分类，以逗号分隔，最大不超过5个。
        /// </summary>
        public string Category { get; set; }
        public string Keyword { get; set; }
        /// <summary>
        /// 传出经纬度偏移类型，1:高德坐标系偏移，2:图吧坐标系偏移，如不传入，默认值为1
        /// </summary>
        public int Out_offset_type { get; set; }
        public int Platform { get; set; }
        /// <summary>
        /// 根据是否有优惠券来筛选返回的商户，1:有，0:没有
        /// </summary>
        public int Has_coupon { get; set; }
        /// <summary>
        /// 根据是否有团购来筛选返回的商户，1:有，0:没有
        /// </summary>
        public int Has_deal { get; set; }
        /// <summary>
        /// 根据是否支持在线预订来筛选返回的商户，1:有，0:没有
        /// </summary>
        public int Has_online_reservation { get; set; }
        /// <summary>
        /// 结果排序，1:默认，2:星级高优先，3:产品评价高优先，4:环境评价高优先，5:服务评价高优先，6:点评数量多优先，7:离传入经纬度坐标距离近优先，8:人均价格低优先，9：人均价格高优先
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 每页返回的商户结果条目数上限，最小值1，最大值40，如不传入默认为20
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// 返回数据格式，可选值为json或xml，如不传入，默认值为json
        /// </summary>
        public string Format { get; set; }

    }
}