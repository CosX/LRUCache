Namespace Interfaces
    Public Interface ILRUCache(Of TKey, TValue)

        Default Property Item(key As TKey) As TValue

        Sub Add(key As TKey, value As TValue)

        Sub Flush()

        Property MaxSize As Integer
        ReadOnly Property Count As Integer

        ReadOnly Property ImplementedBy As String

    End Interface

End Namespace