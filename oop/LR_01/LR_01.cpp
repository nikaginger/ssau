#define _CRT_SECURE_NO_WARNINGS
#define MAX_LENGTH 80

#include <iostream>
#include <cstring>
#include <cstdlib>
#include <cstdio>
#include <windows.h>
#include <cassert>

using namespace std;

// Класс СЛОВО
class Word {
public:
    char* data;

    // Конструктор по умолчанию
    Word() {
        data = (char*)malloc(1);
        if (data) data[0] = '\0';
    }

    // Деструктор
    ~Word() {
        if (data) {
            free(data);
            data = nullptr;
        }
    }

    // Длина слова
    int length() const {
        return strlen(data);
    }

    // Получение слова
    const char* getData() const {
        return data;
    }
};

// Класс ПРЕДЛОЖЕНИЕ
class Sentence {
private:
    Word** words;
    int count;

public:
    // Получение массива слова
    Word** getWords() { return words; }

    // Получение количества слов
    int getCount() { return count; }

    // Конструктор по умолчанию (с вводом с клавиатуры)
    Sentence() {
        words = nullptr;
        count = 0;

        cout << "Введите предложение (до 80 символов):\n";

        char buffer[MAX_LENGTH + 1];
        int i = 0;
        char c;
        while (i < MAX_LENGTH && (c = getchar()) != '\n' && c != EOF) {
            buffer[i++] = c;
        }
        buffer[i] = '\0';

        // Разбиение предложения на слова
        char* token = strtok(buffer, " ");
        while (token != nullptr) {
            words = (Word**)realloc(words, (count + 1) * sizeof(Word*));
            assert(words != nullptr);
            words[count] = (Word*)malloc(sizeof(Word));
            assert(words[count] != nullptr);
            words[count]->data = (char*)malloc(strlen(token) + 1);
            assert(words[count]->data != nullptr);
            strcpy(words[count]->data, token);
            count++;
            token = strtok(nullptr, " ");
        }
    }

    // Конструктор по массиву слов (копирование)
    Sentence(Word** srcWords, int srcCount) {
        count = srcCount;
        words = (Word**)malloc(count * sizeof(Word*));
        if (!words) {
            count = 0;
            return;
        }

        for (int i = 0; i < count; i++) {
            words[i] = (Word*)malloc(sizeof(Word));
            assert(words[i] != nullptr);
            words[i]->data = (char*)malloc(strlen(srcWords[i]->data) + 1);
            assert(words[i]->data != nullptr);
            strcpy(words[i]->data, srcWords[i]->data);
        }
    }

    // Деструктор
    ~Sentence() {
        if (words) {
            for (int i = 0; i < count; i++) {
                free(words[i]->data);
                free(words[i]);
            }
            free(words);
            words = nullptr;
        }
    }

    // Сортировка слов по лексикографическому порядку
    void sortByLexicographic() {
        for (int i = 0; i < count - 1; i++) {
            for (int j = i + 1; j < count; j++) {
                if (strcmp(words[i]->getData(), words[j]->getData()) > 0) {
                    Word* temp = words[i];
                    words[i] = words[j];
                    words[j] = temp;
                }
            }
        }
    }

    // Формирование предложения в строку
    char* buildSentence() {
        if (count == 0) return nullptr;

        int total_len = 0;
        for (int i = 0; i < count; i++) total_len += words[i]->length();
        total_len += count; // пробелы + '\0'

        char* result = (char*)malloc(total_len);
        if (!result) return nullptr;
        result[0] = '\0';

        for (int i = 0; i < count; i++) {
            strcat(result, words[i]->getData());
            if (i < count - 1) strcat(result, " ");
        }
        return result;
    }

    void print(const char* msg = nullptr) {
        if (msg) cout << msg << "\n";
        char* s = buildSentence();
        if (s) {
            printf("%s\n", s);
            free(s);
        }
    }
};

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    // Исходное предложение
    Sentence original;

    // Копия для сортировки
    Sentence copy(original.getWords(), original.getCount());
    copy.sortByLexicographic();

    cout << "\nПредложение в лексикографическом порядке:\n";
    copy.print();

    return 0;
}
