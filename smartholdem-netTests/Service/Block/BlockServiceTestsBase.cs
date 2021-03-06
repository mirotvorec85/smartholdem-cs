﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils.Enum;
using SmartHoldemNet.Model.Account;
using SmartHoldemNet.Model.Delegate;
using SmartHoldemNet.Model.Block;
using SmartHoldemNet.Utils;
using SmartHoldemNet.Tests;

namespace SmartHoldemNet.Service.Block.Tests
{
    public class BlockServiceTestsBase : TestsBase
    {
        protected int _height = 697654;
        protected string _generatorPublicKey = "02090a83979b14f6c1eda93bb942d278b81fa2e4515ef54450ed084906ebf2ef12";

        public void InitializeBlockServiceTest()
        {
            base.Initialize();

            Setup();
        }

        public async Task InitializeBlockServiceAsyncTest()
        {
            await base.InitializeAsync();

            Setup();
        }

        private void Setup()
        {
            if (base.USE_DEV_NET)
            {
                _height = 222495;
                _generatorPublicKey = "0293b54b3afb129046948d66fcb029efc421d21634b8cd18b92878daecd53fecd7";
            }
        }

        public void GetAllResultTest(SmartHoldemBlockList blocks)
        {
            Assert.IsNotNull(blocks);
            Assert.IsNotNull(blocks.Blocks);
            Assert.IsTrue(blocks.Success);
            Assert.IsNull(blocks.Error);
            Assert.IsTrue(blocks.Blocks.Count > 0);
        }

        public void GetBlocksResultTest(SmartHoldemBlockList blocks)
        {
            Assert.IsNotNull(blocks);
            Assert.IsNotNull(blocks.Blocks);
            Assert.IsTrue(blocks.Success);
            Assert.IsNull(blocks.Error);
            Assert.IsTrue(blocks.Blocks.Count == 1);
            Assert.IsTrue(blocks.Blocks.First().Height == _height);
            Assert.IsTrue(blocks.Blocks.First().GeneratorPublicKey == _generatorPublicKey);
        }

        public void GetByIdResultTest(SmartHoldemBlockResponse block)
        {
            Assert.IsNotNull(block);
            Assert.IsTrue(block.Success);
            Assert.IsNull(block.Error);
            Assert.IsNotNull(block.Block);
        }

        public void GetByIdErrorResultTest(SmartHoldemBlockResponse block)
        {
            Assert.IsNotNull(block);
            Assert.IsFalse(block.Success);
            Assert.IsNotNull(block.Error);
        }

        public void GetEpochResultTest(DateTime epoch)
        {
            Assert.AreNotEqual(DateTime.MinValue, epoch);
            Assert.AreEqual(636468660000000000, epoch.Ticks);
        }

        public void GetHeightResultTest(long height)
        {
            Assert.AreNotEqual(0, height);
        }

        public void GetNetHashResultTest(string netHash)
        {
            Assert.IsNotNull(netHash);
        }

        public void GetFeesResultTest(Fees fees)
        {
            Assert.IsNotNull(fees);
        }

        public void GetMilestoneResultTest(int milestone)
        {
            Assert.IsNotNull(milestone);
        }

        public void GetRewardResultTest(int reward)
        {
            Assert.AreNotEqual(0, reward);
        }

        public void GetStatusResultTest(SmartHoldemBlockChainStatus status)
        {
            Assert.IsNotNull(status);
            Assert.IsTrue(status.Success);
            Assert.IsNull(status.Error);
        }
    }
}