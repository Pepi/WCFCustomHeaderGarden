using HelloWorldCommon.DataContracts;
namespace HelloWorldCommon.Extensions
{
    public static class ClaimsHeaderContext
    {
        public static ClaimsHeader HeaderInformation;

        static ClaimsHeaderContext()
        {
            HeaderInformation = new ClaimsHeader();
        }
    }
}
