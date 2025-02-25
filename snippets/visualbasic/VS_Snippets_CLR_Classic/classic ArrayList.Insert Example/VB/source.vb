﻿' <Snippet1>
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new ArrayList using Insert instead of Add.
        Dim myAL As New ArrayList()
        myAL.Insert(0, "The")
        myAL.Insert(1, "fox")
        myAL.Insert(2, "jumps")
        myAL.Insert(3, "over")
        myAL.Insert(4, "the")
        myAL.Insert(5, "dog")
        
        ' Creates and initializes a new Queue.
        Dim myQueue As New Queue()
        myQueue.Enqueue("quick")
        myQueue.Enqueue("brown")
        
        ' Displays the ArrayList and the Queue.
        Console.WriteLine("The ArrayList initially contains the following:")
        PrintValues(myAL)
        Console.WriteLine("The Queue initially contains the following:")
        PrintValues(myQueue)
        
        ' Copies the Queue elements to the ArrayList at index 1.
        myAL.InsertRange(1, myQueue)
        
        ' Displays the ArrayList.
        Console.WriteLine("After adding the Queue, the ArrayList now contains:")
        PrintValues(myAL)
        
        ' Search for "dog" and add "lazy" before it.
        myAL.Insert(myAL.IndexOf("dog"), "lazy")
        
        ' Displays the ArrayList.
        Console.WriteLine("After adding ""lazy"", the ArrayList now contains:")
        PrintValues(myAL)
        
        ' Add "!!!" at the end.
        myAL.Insert(myAL.Count, "!!!")
        
        ' Displays the ArrayList.
        Console.WriteLine("After adding ""!!!"", the ArrayList now contains:")
        PrintValues(myAL)
        
        ' Inserting an element beyond Count throws an exception.
        Try
            myAL.Insert(myAL.Count + 1, "anystring")
        Catch myException As Exception
            Console.WriteLine("Exception: " + myException.ToString())
        End Try
    End Sub    
    
    Public Shared Sub PrintValues(myList As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myList
            Console.Write("   {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class

' This code produces the following output.
' 
' The ArrayList initially contains the following:
'     The    fox    jumps    over    the    dog
' The Queue initially contains the following:
'     quick    brown
' After adding the Queue, the ArrayList now contains:
'     The    quick    brown    fox    jumps    over    the    dog
' After adding "lazy", the ArrayList now contains:
'     The    quick    brown    fox    jumps    over    the    lazy    dog
' After adding "!!!", the ArrayList now contains:
'     The    quick    brown    fox    jumps    over    the    lazy    dog    !!!
' Exception: System.ArgumentOutOfRangeException: Insertion index was out of range.  Must be non-negative and less than or equal to size.
' Parameter name: index
'    at System.Collections.ArrayList.Insert(Int32 index, Object value)
'    at SamplesArrayList.Main()
' </Snippet1>
