#1
array = [int(input()) for i in range(int(input()))]
new_array = [array[i] for i in range(1, len(array), 2)]
new_a = [a for a in array if a%2 == 1]  

#2
lenght_string = len(set(input().split(' ')))