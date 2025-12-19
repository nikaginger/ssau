#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <windows.h>
#include <assert.h>

// структура ДАТЧИК
struct Sensor {
    unsigned shifr;
    char name[41];
};

// структура ПОДСИСТЕМА
struct Subsystem {
    unsigned shifr;
    char name[41];
};

// структура СВЯЗЬ
struct Link {
    unsigned long sensor_idx;
    unsigned long subsys_idx;
};

// класс ФАЙЛ_ДЛЯ_ДАТЧИКОВ
class SensorFile {
private:
    FILE* file;
    char* filename;

public:
    // конструктор: открыть файл в режиме append+read (ab+)
    SensorFile(const char* fname) {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, "ab+");
        if (!file) {
            fprintf(stderr, "Не удалось открыть или создать файл %s\n", filename);
            free(filename);
            filename = nullptr;
        }
    }

    // деструктор: закрыть файл и освободить имя
    ~SensorFile() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    // добавление датчика, возвращает позицию только что записанной записи
    unsigned long addSensor(unsigned shifr, const char* name) {
        assert(file);
        Sensor s;
        s.shifr = shifr;
        strncpy(s.name, name, 40);
        s.name[40] = '\0';

        // записываем в режиме append (не делаем fseek до конца)
        if (fwrite(&s, sizeof(Sensor), 1, file) != 1) {
            // ошибка записи
            fflush(file);
            return (unsigned long)-1;
        }
        fflush(file);

        // позиция конца после записи
        long endpos = ftell(file);
        if (endpos < 0) return (unsigned long)-1;
        unsigned long pos = (unsigned long)(endpos - (long)sizeof(Sensor));
        return pos;
    }

    // поиск датчика по шифру, возвращает позицию
    bool findSensor(unsigned shifr, Sensor& s, unsigned long& pos) {
        assert(file);
        // читаем с начала
        if (fseek(file, 0, SEEK_SET) != 0) return false;
        Sensor temp;
        while (fread(&temp, sizeof(Sensor), 1, file) == 1) {
            if (temp.shifr == shifr) {
                s = temp;
                long p = ftell(file);
                pos = (unsigned long)(p - (long)sizeof(Sensor));
                return true;
            }
        }
        return false;
    }
};

// класс ФАЙЛ_ДЛЯ_ПОДСИСТЕМ
class SubsystemFile {
private:
    FILE* file;
    char* filename;

public:
    // конструктор: открыть файл в режиме append+read (ab+)
    SubsystemFile(const char* fname) {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, "ab+");
        if (!file) {
            fprintf(stderr, "Не удалось открыть или создать файл %s\n", filename);
            free(filename);
            filename = nullptr;
        }
    }

    // деструктор
    ~SubsystemFile() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    // добавление подсистемы, вернуть позицию
    unsigned long addSubsystem(unsigned shifr, const char* name) {
        assert(file);
        Subsystem s;
        s.shifr = shifr;
        strncpy(s.name, name, 40);
        s.name[40] = '\0';

        // записываем
        if (fwrite(&s, sizeof(Subsystem), 1, file) != 1) {
            fflush(file);
            return (unsigned long)-1;
        }
        fflush(file);

        long endpos = ftell(file);
        if (endpos < 0) return (unsigned long)-1;
        unsigned long pos = (unsigned long)(endpos - (long)sizeof(Subsystem));
        return pos;
    }

    // получить подсистему по позиции
    bool getSubsystemByPos(unsigned long pos, Subsystem& s) {
        assert(file);
        if (fseek(file, (long)pos, SEEK_SET) != 0) return false;
        return fread(&s, sizeof(Subsystem), 1, file) == 1;
    }

    // найти подсистему по шифру — полезный метод
    bool findSubsystemByShifr(unsigned shifr, Subsystem& s, unsigned long& pos) {
        assert(file);
        if (fseek(file, 0, SEEK_SET) != 0) return false;
        Subsystem temp;
        while (fread(&temp, sizeof(Subsystem), 1, file) == 1) {
            if (temp.shifr == shifr) {
                s = temp;
                long p = ftell(file);
                pos = (unsigned long)(p - (long)sizeof(Subsystem));
                return true;
            }
        }
        return false;
    }
};

// класс ФАЙЛ_ДЛЯ_СВЯЗЕЙ
class LinkFile {
private:
    FILE* file;
    char* filename;

public:
    // конструктор: открыть файл в режиме append+read (ab+)
    LinkFile(const char* fname) {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, "ab+");
        if (!file) {
            fprintf(stderr, "Не удалось открыть или создать файл %s\n", filename);
            free(filename);
            filename = nullptr;
        }
    }

    // деструктор
    ~LinkFile() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    // добавление связи (позиции записей)
    void addLink(unsigned long sensor_pos, unsigned long subsys_pos) {
        assert(file);
        Link l;
        l.sensor_idx = sensor_pos;
        l.subsys_idx = subsys_pos;

        // записываем
        fwrite(&l, sizeof(Link), 1, file);
        fflush(file);
    }

    // поиск подсистемы по позиции датчика
    bool findSubsystemForSensor(unsigned long sensor_pos, unsigned long& subsys_pos) {
        assert(file);
        if (fseek(file, 0, SEEK_SET) != 0) return false;
        Link l;
        while (fread(&l, sizeof(Link), 1, file) == 1) {
            if (l.sensor_idx == sensor_pos) {
                subsys_pos = l.subsys_idx;
                return true;
            }
        }
        return false;
    }
};

// меню
void menu() {
    printf("1. Добавить подсистему\n");
    printf("2. Добавить датчик\n");
    printf("3. Найти подсистему по шифру датчика\n");
    printf("0. Выход\n");
    printf("Выбор: ");
}

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    SensorFile sensorFile("SENSOR.DAT");
    SubsystemFile subsysFile("SUBSYS.DAT");
    LinkFile linkFile("LINK.IDX");

    int choice;
    do {
        menu();
        if (scanf("%d", &choice) != 1) break;

        if (choice == 2) {
            unsigned shifr;
            char name[41];
            printf("Введите шифр датчика: ");
            scanf("%u", &shifr);
            printf("Введите название датчика: ");
            getchar();
            fgets(name, 41, stdin);
            name[strcspn(name, "\n")] = 0;

            unsigned long pos = sensorFile.addSensor(shifr, name);
            if (pos == (unsigned long)-1) {
                printf("Ошибка при добавлении датчика.\n");
                continue;
            }
            printf("Датчик добавлен. Позиция: %lu\n", pos);

            unsigned shifrSubsys;
            printf("Введите шифр подсистемы для связи с датчиком: ");
            scanf("%u", &shifrSubsys);

            // ищем подсистему по шифру через класс SubsystemFile
            Subsystem sub;
            bool foundSub = false;
            unsigned long posSubsys;
            if (subsysFile.findSubsystemByShifr(shifrSubsys, sub, posSubsys)) {
                foundSub = true;
            }

            if (foundSub) {
                linkFile.addLink(pos, posSubsys);
                printf("Связь добавлена.\n");
            }
            else {
                printf("Подсистема не найдена.\n");
            }
        }
        else if (choice == 1) {
            unsigned shifr;
            char name[41];
            printf("Введите шифр подсистемы: ");
            scanf("%u", &shifr);
            printf("Введите название подсистемы: ");
            getchar();
            fgets(name, 41, stdin);
            name[strcspn(name, "\n")] = 0;
            unsigned long pos = subsysFile.addSubsystem(shifr, name);
            if (pos == (unsigned long)-1) {
                printf("Ошибка при добавлении подсистемы.\n");
            }
            else {
                printf("Подсистема добавлена. Позиция: %lu\n", pos);
            }
        }
        else if (choice == 3) {
            unsigned shifr;
            printf("Введите шифр датчика: ");
            scanf("%u", &shifr);

            Sensor s;
            unsigned long posSensor;
            if (!sensorFile.findSensor(shifr, s, posSensor)) {
                printf("Датчик не найден.\n");
                continue;
            }

            unsigned long posSubsys;
            if (linkFile.findSubsystemForSensor(posSensor, posSubsys)) {
                Subsystem sub;
                if (subsysFile.getSubsystemByPos(posSubsys, sub)) {
                    printf("Датчик \"%s\" принадлежит подсистеме \"%s\"\n", s.name, sub.name);
                }
                else {
                    printf("Не удалось прочитать подсистему по позиции.\n");
                }
            }
            else {
                printf("Для данного датчика не найдена подсистема.\n");
            }
        }

    } while (choice != 0);

    return 0;
}
