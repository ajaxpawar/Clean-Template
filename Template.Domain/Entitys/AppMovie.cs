using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entitys
{
    /// <summary>
    /// Create Entity 
    /// This is Sample Entity
    /// Create your entity in this folder
    /// </summary>
    public class AppMovie
    {
        public MovieId Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        
    }
    public record MovieId(Guid Value);

}
