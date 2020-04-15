using System.Collections.Generic;

namespace Rivader.Domain.Models
{
    public class Translation
    {
        public int Id { get; set; }
        public List<CulturedLabel> CulturedLabels { get; set; }
    }
}
