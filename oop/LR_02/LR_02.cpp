#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <windows.h>
#include <assert.h>

// Класс СТРОКА
class Line {
public:
    char* data;

    Line(const char* src) {
        if (src) {
            data = (char*)malloc(strlen(src) + 1);
            assert(data != nullptr);
            strcpy(data, src);
        }
        else {
            data = (char*)malloc(1);
            assert(data != nullptr);
            data[0] = '\0';
        }
    }

    ~Line() { if (data) free(data); }

    int length() const { return (int)strlen(data); }
    const char* getData() const { return data; }
};

// Класс СПИСОК_СТРОК
class LineList {
private:
    Line** lines;
    int count;
    int capacity;

    void resize() {
        int newCapacity = (capacity == 0) ? 1 : capacity * 2;
        Line** temp = (Line**)malloc(newCapacity * sizeof(Line*));
        assert(temp != nullptr);

        for (int i = 0; i < count; i++)
            temp[i] = lines[i];

        free(lines);
        lines = temp;
        capacity = newCapacity;
    }

public:
    LineList() : lines(nullptr), count(0), capacity(0) {}
    ~LineList() {
        for (int i = 0; i < count; i++)
            delete lines[i];
        free(lines);
    }

    void addLine(const char* text) {
        if (count >= capacity) resize();
        lines[count++] = new Line(text);
    }

    Line* getLine(int index) const {
        if (index < 0 || index >= count) return nullptr;
        return lines[index];
    }

    int size() const { return count; }

    // Сортировка по длине строки
    static int compareLines(const void* a, const void* b) {
        Line* l1 = *(Line**)a;
        Line* l2 = *(Line**)b;
        return l1->length() - l2->length();
    }

    void sortByLength() {
        if (count > 1)
            qsort(lines, count, sizeof(Line*), compareLines);
    }
};

// Класс FileWriter
class FileWriter {
private:
    FILE* file;
    char* filename;

public:
    FileWriter(const char* fname, const char* mode = "w") {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, mode);
        if (!file) {
            printf("Не удалось открыть файл %s для записи.\n", filename);
            free(filename);
            filename = nullptr;
        }
    }

    ~FileWriter() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    void writeLines(LineList& list) {
        if (!file) return;
        for (int i = 0; i < list.size(); i++)
            fprintf(file, "%s\n", list.getLine(i)->getData());
    }
};

// Класс FileReader
class FileReader {
private:
    FILE* file;
    char* filename;

public:
    FileReader(const char* fname) {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, "r");
        if (!file) {
            printf("Не удалось открыть файл %s для чтения.\n", filename);
            free(filename);
            filename = nullptr;
        }
    }

    ~FileReader() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    void readAllLines(LineList& list) {
        if (!file) return;
        char buffer[1024];
        while (fgets(buffer, sizeof(buffer), file)) {
            buffer[strcspn(buffer, "\n")] = 0;
            list.addLine(buffer);
        }
    }
};

// Ввод строк с клавиатуры
void inputLines(LineList& list) {
    printf("Введите строки через пробел и нажмите Enter:\n");
    char input[1024];
    fgets(input, sizeof(input), stdin);
    input[strcspn(input, "\n")] = 0;

    char* token = strtok(input, " ");
    while (token) {
        list.addLine(token);
        token = strtok(nullptr, " ");
    }
}

// Главная функция
int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    char filename[256];
    LineList originalLines;

    // 1. Ввод исходного файла и строк
    printf("Введите имя исходного файла: ");
    fgets(filename, sizeof(filename), stdin);
    filename[strcspn(filename, "\n")] = 0;

    inputLines(originalLines);

    // Сохраняем строки в исходный файл
    FileWriter writer1(filename);
    writer1.writeLines(originalLines);
    printf("Оригинальный файл '%s' сохранён.\n", filename);

    // 2. Создаём новый файл для сортированных строк
    printf("Введите имя нового файла для отсортированных строк: ");
    fgets(filename, sizeof(filename), stdin);
    filename[strcspn(filename, "\n")] = 0;

    LineList sortedLines;
    // Копируем строки из исходного списка
    for (int i = 0; i < originalLines.size(); i++)
        sortedLines.addLine(originalLines.getLine(i)->getData());

    sortedLines.sortByLength(); // Сортируем копию

    FileWriter writer2(filename);
    writer2.writeLines(sortedLines);
    printf("Отсортированный файл '%s' создан.\n", filename);

    // 3. Чтение нового файла и вывод его на консоль
    LineList readSorted;
    FileReader reader(filename);
    reader.readAllLines(readSorted);

    printf("Содержимое отсортированного файла:\n");
    for (int i = 0; i < readSorted.size(); i++)
        printf("%s\n", readSorted.getLine(i)->getData());

    return 0;
}
