using atFrameWork2.BaseFramework;

namespace ATframework3demo.BaseFramework
{
    class CaseCollectionGenerator
    {
        public List<TestCase> FrameworkCaseCollection { get; } = new List<TestCase>();

        public CaseCollectionGenerator()
        {
            CaseCollectionBuilder.ActivateTestCaseProvidersInstances(FrameworkCaseCollection);
        }
    }
}
