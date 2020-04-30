using System;
using Entities;
using NUnit.Framework;

namespace Testing.Editor_Tests
{
    [TestFixture]
    public class EntityTest
    {
        class EntityMock : Entity
        {
            public EntityMock(float maxHP = 100) : base(maxHP)
            {
            }

            public EntityMock(float maxHP, float startingHP) : base(maxHP, startingHP)
            {
            }
        }

        #region Damage

        [Test, Category("HP/Damage")]
        public void TakeDamageReducesHPAmount()
        {
            // Assemble
            Entity entity = new EntityMock();
            float initialHP = entity.CurrentHP;
            float damage = 5;

            // Act
            entity.TakeDamage(damage);

            // Assert
            Assert.AreEqual(initialHP - damage, entity.CurrentHP);
        }

        [Test, Category("HP/Damage")]
        public void HPCannotGoBelowZero()
        {
            // Assemble
            Entity aliveEntity = new EntityMock(100, 1);

            // Act
            aliveEntity.TakeDamage(10000);

            // Assert
            Assert.AreEqual(0, aliveEntity.CurrentHP);
        }

        [Test, Category("HP/Damage")]
        public void CannotDamageDeadEntities()
        {
            // Assemble
            float maxHP = 100;
            Entity deadEntity = new EntityMock(maxHP);
            deadEntity.TakeDamage(maxHP);

            if (deadEntity.IsAlive)
                Assert.Fail("Entity should be dead at this point.");

            // Act and Assert
            try
            {
                deadEntity.TakeDamage(100);
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
            // Assemble
            float maxHP = 100;
            Entity entity = new EntityMock(maxHP);

            // Act
            entity.TakeHealing(500);
            entity.TakeDamage(50);
            entity.TakeHealing(500);

            // Assert
            Assert.AreEqual(maxHP, entity.CurrentHP);
            try
            {
                var unused = new EntityMock(10, 1000);
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
            Entity entity = new EntityMock();
            float initialHP = entity.CurrentHP;
            float damage = 5;

            // Act
            entity.TakeDamage(damage);

            // Assert
            Assert.AreEqual(initialHP - damage, entity.CurrentHP);
        }

        [Test, Category("HP/Heal")]
        public void CannotHealDeadEntities()
        {
            // Assemble
            float maxHP = 100;
            Entity deadEntity = new EntityMock(maxHP);
            deadEntity.TakeDamage(maxHP);

            if (deadEntity.IsAlive)
                Assert.Fail("Entity should be dead at this point.");

            // Act and Assert
            try
            {
                deadEntity.TakeHealing(100);
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