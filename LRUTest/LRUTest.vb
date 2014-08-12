Imports System.Text
Imports LRU
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class LRUTest

    <TestMethod()> Public Sub AddToCache()
        Dim lru As New LruCache(Of String, String)
        lru.MaxSize = 5
        lru.Add("String1", "1")
        lru.Add("String2", "2")
        lru.Add("String3", "3")

        Assert.AreEqual(lru.Count, 3)
    End Sub

    <TestMethod()> Public Sub MaxSizeLimit()
        Dim lru As New LruCache(Of String, String)
        lru.MaxSize = 5
        lru.Add("String1", "1")
        lru.Add("String2", "2")
        lru.Add("String3", "3")
        lru.Add("String4", "4")
        lru.Add("String5", "5")
        lru.Add("String6", "6")

        Assert.AreEqual(lru.Count, 5)
    End Sub

    <TestMethod()> Public Sub SetValue()
        Dim lru As New LruCache(Of String, String)
        lru.MaxSize = 5
        lru.Add("String1", "1")
        lru.Add("String2", "2")
        lru.Add("String3", "3")
        lru.Add("String4", "4")

        lru.Item("String3") = "Jeg er modda!"

        Assert.AreEqual(lru.Item("String3"), "Jeg er modda!")
    End Sub

End Class