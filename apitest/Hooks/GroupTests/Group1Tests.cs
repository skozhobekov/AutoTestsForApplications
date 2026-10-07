using FluentAssertions;

namespace apitest.Hooks.GroupTests;
using NUnit.Framework;


[TestFixture]
//[Parallelizable(ParallelScope.Children)]
//[Parallelizable(ParallelScope.Fixtures)]
//[Parallelizable(ParallelScope.All)]
[Parallelizable(ParallelScope
    .Self)] //тест может идти параллельно с другими, но не с собственными параметризованными запусками

public class Group1Tests : HooksForGroupTest1

{
    [Test]
    [Repeat(10)] // для флайки тестов: если хоть один раз из 10 упадет, то тест будет красным
    public void Test1()
    {
        true.Should().BeTrue();

    }

    [Test]
    [Parallelizable]
    public void Test2()
    {
        true.Should().BeTrue();

    }

    [Test]
    [Timeout(1)] //если тест перевалит за 30 минут, он упадет, даже если он успешно пройден
    public void Test3()
    {
        true.Should().BeTrue();
    }

    [Test]
    [Retry(10)] // при падении тест перезапускается до успешного исхода
    public void Test4()
    {
        true.Should().BeTrue();

    }

    [Test]
    [Ignore("причина")]
    public void Test5()
    {
        true.Should().BeTrue();
    }

    [Test]
    [Category("QA")]
    [Category("Fake")]
    [Order(1)]
    public void Test6()
    {
        true.Should().BeTrue();
    }

    [Test]
    [Description("my description")]
    public void Test7()
    {
        true.Should().BeTrue();

    }
}