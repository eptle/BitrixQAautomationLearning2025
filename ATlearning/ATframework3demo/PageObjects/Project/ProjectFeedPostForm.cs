using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Project
{
    public class ProjectFeedPostForm
    {
        public ProjectFeedPostForm(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public ProjectFeedPostForm AddText(object Text)
        {
            throw new NotImplementedException();
            return new ProjectFeedPostForm();
        }

        public ProjectFeed Send()
        {
            throw new NotImplementedException();
            return new ProjectFeed();
        }
    }
}
