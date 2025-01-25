using atFrameWork2.BaseFramework.LogTools;
using System.Reflection;

namespace atFrameWork2.BaseFramework
{
    public abstract class CaseCollectionBuilder
    {
        List<TestCase> CaseCollection { get; } = new List<TestCase>();

        public CaseCollectionBuilder()
        {
            CaseCollection.AddRange(GetCases());
        }

        abstract protected List<TestCase> GetCases();

        public static void ActivateTestCaseProvidersInstances(List<TestCase> resultCaseCollection)
        {
            IEnumerable<Type> subclassTypes = Assembly
                .GetAssembly(typeof(CaseCollectionBuilder))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(CaseCollectionBuilder)));

            foreach (var subClassType in subclassTypes)
            {
                try
                {
                    var instance = Activator.CreateInstance(subClassType) as CaseCollectionBuilder;
                    resultCaseCollection.AddRange(instance.CaseCollection);
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }
        }
    }
}
