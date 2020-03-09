using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QueryProxy.Model
{

    [Table("fruits")]
    public class Fruit
    {
        [Key]
        public int RowId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
