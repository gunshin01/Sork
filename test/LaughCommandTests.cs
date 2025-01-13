namespace Sork.Tests;
using Sork.Commands;
[TestClass]
public sealed class LaughCommandsTests
{
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenInputIsCapitalized()
    {
        //Arrange
        var command = new LaughCommand(new UserInputOutput());
        //Act
        var result = command.Handles("LOL");
        //Assert
        Assert.IsTrue(result);
    }
}
