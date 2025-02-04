﻿namespace Sork.Tests;
using Sork.Commands;
using Sork.World;
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
    [TestMethod]
    public void Handle_ShouldReturnTrue_WhenLowercaseInputIsProvided()
    {
        //Arrange
        var command = new LaughCommand(new UserInputOutput());
        //Act
        var result = command.Handles("lol");
        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Execute_ShouldOutputMessage()
    {
        //Arrange
        var io = new TestInputOutput();
        var command = new LaughCommand(io);
        var gameState = GameState.Create(io);
        //Act
        var result = command.Execute("LAUGH", gameState);
        //Assert
        Assert.IsTrue(result.IsHandled);
        Assert.IsFalse(result.RequestExit);
        Assert.AreEqual(2, io.Outputs.Count);
        Assert.AreEqual("You", io.Outputs[0]);
        Assert.AreEqual(" Laughed out Loud!", io.Outputs[1]);
    }
}
