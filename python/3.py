import os.path

def task():
    print('''Лабораторная работа №3
Вариант № 25. Выполнил студент группы 6101-020302D Бренева Вероника
Задание:
В исходном текстовом файле записаны строки, содержащие произвольные алфавитно-цифровые символы. 
Требуется написать, которая для каждой строки исходного файла будет составлять и выводить в результирующий файл из тех цифр, 
которые не встречаются во входных данных, максимальное число.

Введите название  исходного файла: ''')

def getNumber(s):
    alf = '9876543210'
    for i in range (len(s)):
        if s[i] in alf:
            alf = alf.replace(s[i], '')
    res = alf
    return res

def fileToFile(name1, name2):
    with open(name1, 'r') as f1, open(name2, 'w') as f2:
        for line in f1.readlines():
            if line == "\n":
                f2.write("\n")
            else:
                res = getNumber(line)
                f2.write(res + '\n')

task()
key = 1
while key:
    filename1 = str(input()) + '.txt'
    if os.path.exists(filename1):
        filename2 = str(input("Введите название итогового файла:\n")) + '.txt'
        fileToFile(filename1, filename2)
        print('Задание выполнено')
        key = 0
    else:
        print('Введенное название исходного файла некорректно.Введите название заново:')
