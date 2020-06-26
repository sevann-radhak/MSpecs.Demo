using FakeItEasy;
using Machine.Specifications;
using System;

namespace MSpecs.Demo.Tests
{
    [Subject(typeof(UserManager))]
    public class User_Id_Passed
    {
        static UserManager Subject;
        static User User;

        Establish context = () =>
        {
            var userProvider = A.Fake<IUserProvider>();
            A.CallTo(() => userProvider.Get(A<int>._)).Returns(new User { Name = "Sevann Radhak" });
            Subject = new UserManager(userProvider);
        };

        Because of = () => User = Subject.Get(1);

        It should_return_a_non_null_User = () => User.ShouldNotBeNull();
        
        It should_return_User_Name_as_Sevann_Radhak = () 
            => User.Name.ShouldBeEqualIgnoringCase("Sevann Radhak");
    }

    [Subject(typeof(UserManager))]
    public class User_Id_Passed_Is_Negative_Integer
    {
        static UserManager Subject;
        static Exception Exception;

        Establish context = () =>
        {
            var userProvider = A.Fake<IUserProvider>();
            Subject = new UserManager(userProvider);
        };

        Because of = () => Exception = Catch.Exception(() => Subject.Get(-1));

        It should_fail_with_Argument_Exception = () 
            => Exception.ShouldBeOfExactType<ArgumentException>();
    }
}
