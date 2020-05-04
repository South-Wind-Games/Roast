using NUnit.Framework;
using Roasts.Base;

namespace Testing.Editor_Tests
{
    [TestFixture]
    public class HPTests
    {
        HP testEntity;

        [SetUp]
        public void SetUp()
        {
            testEntity = new HP();
        }

        #region Damage

        [Test, Category("HP/Damage")]
        public void TakeDamageReducesHPAmount()
        {
            // Assemble
            float initialHP = testEntity.CurrentHP;
            float damage = 5;

            // Act
            testEntity.TakeDamage(damage);

            // Assert
            Assert.AreEqual(initialHP - damage, testEntity.CurrentHP);
        }

        [Test, Category("HP/Damage")]
        public void HPCannotGoBelowZero()
        {
            // Act
            testEntity.TakeDamage(testEntity.MaxHP * 100);

            // Assert
            Assert.AreEqual(0, testEntity.CurrentHP);
        }

        [Test, Category("HP/Damage")]
        public void CannotDamageDeadEntities()
        {
            // Assemble
            testEntity.TakeDamage(testEntity.CurrentHP);

            if (testEntity.IsAlive)
                Assert.Fail("Entity should be dead at this point.");

            // Act and Assert
            try
            {
                testEntity.TakeDamage(100);
                Assert.Fail("Successfully attempted to damage a dead IDamageable. This shouldn't happen.");
            }
            catch (HP.AttemptToInteractWhenDeadException e)
            {
                Assert.Pass("Catched correct exception: " + e);
            }
        }

        #endregion

        #region Heal

        [Test, Category("HP/Heal")]
        public void HPCannotGoAboveMaxHP()
        {
            // Act
            testEntity.TakeHealing(500);
            testEntity.TakeDamage(50);
            testEntity.TakeHealing(500);

            // Assert
            Assert.AreEqual(testEntity.MaxHP, testEntity.CurrentHP);
            try
            {
                var unused = new HP(10, 1000);
                Assert.Fail("Allowed to create Entity with lower maxHP than currentHP.");
            }
            catch (HP.AttemptToSetMaxHPLowerThanHealthException e)
            {
                Assert.Pass("Catched correct exception: " + e);
            }
        }

        [Test, Category("HP/Heal")]
        public void TakeHealIncreasesHPAmount()
        {
            // Assemble
            float initialHP = testEntity.CurrentHP;
            float damage = 5;

            // Act
            testEntity.TakeDamage(damage);

            // Assert
            Assert.AreEqual(initialHP - damage, testEntity.CurrentHP);
        }

        [Test, Category("HP/Heal")]
        public void CannotHealDeadEntities()
        {
            // Assemble
            testEntity.TakeDamage(testEntity.MaxHP);

            if (testEntity.IsAlive)
                Assert.Fail("Entity should be dead at this point.");

            // Act and Assert
            try
            {
                testEntity.TakeHealing(100);
                Assert.Fail("Successfully attempted to heal a dead IDamageable. This shouldn't happen.");
            }
            catch (HP.AttemptToInteractWhenDeadException e)
            {
                Assert.Pass("Catched correct exception: " + e);
            }
        }

        #endregion
    }
}