using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Monopoly;

namespace MonopolyTests
{
    [TestFixture]
    public class PlayerTests
    {
        [TestCase("Test Name")]
        public void WhenPlayerIsInitialised_PlayerNameIsSet(string name)
        {
            #region Arrange
            Player player = new Player(name);
            #endregion

            #region Act
            #endregion

            #region Assert
            Assert.That(player.GetPlayerName, Is.EqualTo(name));
            #endregion

        }

        [TestCase("Test Name")]
        public void WhenPlayerIsInitialised_PlayerStatusIsSet_ToAlive(string name)
        {
            #region Arrange
            Player player = new Player(name);
            #endregion

            #region Act
            #endregion

            #region Assert
            Assert.That(player.GetPlayerStatus, Is.EqualTo(true));
            #endregion

        }

        [TestCase("Test Name")]
        public void WhenPlayerIsInitialised_PlayerBalanceIsSet_To1000(string name)
        {
            #region Arrange
            Player player = new Player(name);
            #endregion

            #region Act
            #endregion

            #region Assert
            Assert.That(player.GetBalance, Is.EqualTo(1000));
            #endregion

        }

        [TestCase("Test Name", 100)]
        [TestCase("Test Name", -100)]
        public void PlayersBalanceIsChanged_WhenChangeBalanceIsCalledWithAValue(string name, int money)
        {
            #region Arrange
            Player player = new Player(name);
            #endregion

            #region Act
            player.ChangeBalance(money);
            #endregion

            #region Assert
            Assert.That(player.GetBalance, Is.EqualTo(1000 + money));
            #endregion

        }

        [TestCase("Test Name")]
        public void PlayerStatusIsSet_ToNotAlive_WhenRemovePlayerIsCalled(string name)
        {
            #region Arrange
            Player player = new Player(name);
            #endregion

            #region Act
            player.RemovePlayer();
            #endregion

            #region Assert
            Assert.That(player.GetPlayerStatus, Is.EqualTo(false));
            #endregion

        }
        [TestCase("Test Name")]
        public void PlayerIDIsSet_ToNotAlive_WhenRemovePlayerIsCalled(string name)
        {
            #region Arrange
            Player player = new Player(name);
            #endregion

            #region Act
            player.RemovePlayer();
            #endregion

            #region Assert
            Assert.That(player.GetPlayerStatus, Is.EqualTo(false));
            #endregion

        }

        [TestCase("Test Name" , 1)]
        public void WhenPlayerIsInitialised_PlayerNameIsSet(string name, int id)
        {
            #region Arrange
            Player player = new Player(name, id);
            #endregion

            #region Act
            #endregion

            #region Assert
            Assert.That(player.GetPlayerID, Is.EqualTo(id));
            #endregion

        }

    }
}
