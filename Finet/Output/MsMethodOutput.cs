using Finet.Model;

namespace Finet.Output
{
    public class MsMethodOutput : BaseOutput
    {
        public int MethodID { get; set; }
        public string MethodName { get; set; }
        public string Stsrc { get; set; }
    }
    public class ListMethodOutput : BaseOutput
    {
        public List<MsMethod> Data { get; set; }
        //public int TotalData { get; set; }
        //public int TotalPage { get; set; }
        public ListMethodOutput()
        {
            Data = new List<MsMethod>();
        }

    }
}
