using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{

    [Test]
    public void PlayerAndFoodCollision()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0, 0, 0, 0), false);
    }

    [Test]
    public void OnlyHorizontalOutMinDistanse()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0, 0, 5, 0), true);
    }

    [Test]
    public void OnlyHorizontalInMinDistanse()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0, 0, 4.9f, 0), false);
    }

    [Test]
    public void OnlyVerticalInMinDistanse()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0, 0, 4.9f, 0), false);
    }

    [Test]
    public void OnlyVerticalOutMinDistanse()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0, 0, 0, 5), true);
    }

    [Test]
    public void NonRectArea()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0, 0, 4.9f, 4.9f), true);
    }

    [Test]
    public void InAreaCenter()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(50, 50, 47.5f, 50), false);
    }

    [Test]
    public void OYAxisTest()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0, 100, 0, 0), true);
    }
    
    [Test]
    public void OXAxisTest()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(100, 0, 0, 0), true);
    }

    [Test]
    public void CorrectWorkWithDouble()
    {
        var eater = new Eating();
        eater.maxX = 100;
        eater.maxY = 100;
        eater.minX = 0;
        eater.minY = 0;
        eater.distanceFood = 5;
        Assert.AreEqual(eater.CheckPointCorrectForPlacingFood(0.7f, 7.8f, 5.9f, 48.8f), true);
    }
}
