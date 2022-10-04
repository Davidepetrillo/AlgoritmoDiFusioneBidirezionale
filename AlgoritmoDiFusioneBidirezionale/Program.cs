/*
 * Algoritmo di fusione bidirezionale - Two-way merge algorithm
 * I dati della prima metà e della seconda metà vengono ordinati e i due elenchi secondari ordinati vengono uniti in un elenco ordinato,
 * che continua a ricorrere fino alla fine
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class TestMergeSort{

    public static void Main(string[] args)
    {
        int[] scores = { 50, 65, 99, 87, 74, 63, 76, 100, 92 };

        MergeSort(scores);

        for(int i =0; i< scores.Length; i++)
        {
            Console.Write(scores[i] + " , ");
        }
    }

    public static void MergeSort(int[] array)
    {
        MergeSort(array, new int[array.Length], 0, array.Length - 1);
    }

    public static void MergeSort(int[] array, int[] temp, int left, int right)
    {
        if(left < right)
        {
            int center = (left + right) / 2;
            MergeSort(array, temp, left, center);
            MergeSort(array, temp, center +1, right);
            Merge(array, temp, left, center +1, right);
        }
    }

    public static void Merge(int[] array, int[] temp, int left, int right, int rightEndIndex)
    {
        int leftEndIndex = right - 1;
        int tempIndex = left;
        int elementNumber = rightEndIndex - left + 1;

        while(left <= leftEndIndex && right <= rightEndIndex)
        {
            if (array[left] <= array[right])
                temp[tempIndex++] = array[left++];
            else
                temp[tempIndex++] = array[right++];
        }

        while(left <= leftEndIndex)
        {
            temp[tempIndex++] = array[left++];
        }

        while(right <= rightEndIndex)
        {
            temp[tempIndex++] = array[right++];
        }

        for (int i = 0; i < elementNumber; i++)
        {
            array[rightEndIndex] = temp[rightEndIndex];
            rightEndIndex--;
        }
    }

}

