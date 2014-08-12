Imports LRU.Interfaces

Public Class LruCache(Of TKey, TValue)
    Implements ILRUCache(Of TKey, TValue)

    Private ReadOnly _lruList As New LinkedList(Of LRUCacheItem(Of TKey, TValue))()
    Private ReadOnly _cacheMap As New Dictionary(Of TKey, LinkedListNode(Of LRUCacheItem(Of TKey, TValue)))()


    Default Public Property Item(ByVal key As TKey) As TValue Implements ILRUCache(Of TKey, TValue).Item
        Get
            If _cacheMap.ContainsKey(key) Then
                Dim value = _cacheMap(key).Value.Value
                Dim cacheItem As New LRUCacheItem(Of TKey, TValue)(key, value)
                _lruList.Remove(cacheItem)
                _lruList.AddLast(cacheItem)
                Return value
            End If
            Return Nothing
        End Get
        Set(ByVal value As TValue)
            If _cacheMap.ContainsKey(key) Then
                Dim cacheItem As New LRUCacheItem(Of TKey, TValue)(key, value)
                Dim node As New LinkedListNode(Of LRUCacheItem(Of TKey, TValue))(cacheItem)
                _cacheMap(key) = node
            End If
        End Set
    End Property

    Public Sub Add(ByVal key As TKey, ByVal value As TValue) Implements ILRUCache(Of TKey, TValue).Add
        Dim cacheItem As New LRUCacheItem(Of TKey, TValue)(key, value)
        Dim node As New LinkedListNode(Of LRUCacheItem(Of TKey, TValue))(cacheItem)
        If Count >= MaxSize Then
            _lruList.RemoveFirst()
            _lruList.AddLast(node)
        Else
            _lruList.AddLast(node)
            _cacheMap.Add(key, node)
        End If
    End Sub

    Public Sub Flush() Implements ILRUCache(Of TKey, TValue).Flush
        _lruList.Clear()
        _cacheMap.Clear()
    End Sub

    Public Property MaxSize() As Integer Implements ILRUCache(Of TKey, TValue).MaxSize

    Public ReadOnly Property Count() As Integer Implements ILRUCache(Of TKey, TValue).Count
        Get
            Return _cacheMap.Count
        End Get
    End Property

    Public ReadOnly Property ImplementedBy() As String Implements ILRUCache(Of TKey, TValue).ImplementedBy
        Get
            Return ""
        End Get
    End Property

End Class

Friend Class LRUCacheItem(Of TKey, TValue)
    Public Sub New(key As TKey, value As TValue)
        Me.Key = key
        Me.Value = Value
    End Sub
    Public Key As TKey
    Public Value As TValue
End Class
