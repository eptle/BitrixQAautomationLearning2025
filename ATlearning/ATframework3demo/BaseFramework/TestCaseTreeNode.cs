namespace ATframework3demo.BaseFramework
{
    public class TestCaseTreeNode
    {
        public TestCaseTreeNode(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public bool IsChecked { get; set; }
    }
}
