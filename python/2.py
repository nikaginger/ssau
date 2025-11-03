import random

def task():
    print ("Лабораторная работа №2\n"
    "Вариант 2, 6101-020302, Бренева Вероника\n"
    "1. В списке целочисленных элементов найти минимальный четный отрицательный элемент \n" 
    "2. С ипользованием цикла while найти в списке индекс первого положительного четного элемента \n"
    "3. Отсортировать список по возрастанию (сортировка вставкой) \n")

def minEvenNegative (a):
    minx = 10**9
    for i in range (len(a)):
        if (a[i] < 0) and (a[i] % 2 == 0) and (a[i] < minx):
            minx = a[i]
    return minx

def indexOfFirstEvenPositive(a):
    i = 0
    n = len(a)
    while (i < (len(a))) and ((a[i] <= 0) or a[i] % 2 != 0):
        i += 1
    return i

def sortInsert(a):
    for i in range(1, len(a)):
        x = a[i]
        j = i - 1
        while ((j >= 0) and (x < a[j])):
            a[j + 1] = a[j]
            j = j - 1
        a[j + 1] = x
    return a

task()
_input = input('Введите способ заполнения списка:\n'
    '1 - ввод элементов списка в одну строку через пробел: \n'
    'любое другое число - автоматическое формирование списка из n элементов: \n')
a = []
print()
if _input == '1':
    print('Введите массив чисел через пробел: ')
    a = list(map(int, input().split()))
else:
    n = input('Введите число n (количество чисел в массиве): ')
    b = int(input('Введите число b (нижнюю границу рандомайзера): '))
    c = int(input('Введите число c (верхнюю границу рандомайзера): '))
    for i in range (int(n)):
        a.append(random.randint(b, c))
    print(a)

print()
minx = minEvenNegative(a)
if minx == 10**9:
        print('Нет четных отрицательных элементов.')
else: print('Минимальный четный отрицательный элемент:', minx)

i = indexOfFirstEvenPositive(a)
if i < len(a):
        print('Индекс первого положительного четного элемента:', i)
else:
        print('Нет четных положительных элементов.')
print('Исходный список:')
print(a)
print('Отсортированный список:')
print(sortInsert(a))
