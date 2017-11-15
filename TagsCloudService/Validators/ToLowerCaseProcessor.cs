using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.Validators
{
    public class ToLowerCaseProcessor : IProcessTag
    {
        public string Process(string tag)
        {
            return tag.ToLower();
        }
    }
}
