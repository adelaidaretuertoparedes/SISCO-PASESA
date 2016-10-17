using System.Linq;

namespace SICO.Infrastructure.CrossCutting.Common
{
    public static  class  CustomStringExtension
    {
        public static string TrimMiddle(this string value)
        {
            string[] elements = value.Split(' ');
            return string.Join(" ", elements.Where(x => x != ""));
        }
    }
}
