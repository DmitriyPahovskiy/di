using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudService.Validators
{
    public interface IProcessTag
    {
        string Process(string tag);
    }
}
