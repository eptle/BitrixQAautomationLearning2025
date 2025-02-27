using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Project
{
    public class ProjectFeed
    {
        public ProjectFeed(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public ProjectFeedPostForm TypeMessageField()
        {
            throw new NotImplementedException();
            return new ProjectFeedPostForm();
        }

        public ProjectFeed ChooseFirstPost()
        {
            throw new NotImplementedException();
            return new ProjectFeed();
        }
    }
}
