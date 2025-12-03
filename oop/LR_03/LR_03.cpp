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
    SensorFile(const char* fname, const char* mode = "rb+") {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, mode);
        if (!file) {
            file = fopen(filename, "wb+");
        }
    }

    ~SensorFile() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    // добавление датчика, возвращает позицию
    unsigned long addSensor(unsigned shifr, const char* name) {
        assert(file);


        Sensor s;
        s.shifr = shifr;
        strncpy(s.name, name, 40);
        s.name[40] = '\0';

        unsigned long pos = ftell(file);
        fwrite(&s, sizeof(Sensor), 1, file);
        fflush(file);
        return pos;
    }

    // поиск датчика по шифру, возвращает позицию
    bool findSensor(unsigned shifr, Sensor& s, unsigned long& pos) {
        assert(file);
        fseek(file, 0, SEEK_SET);
        Sensor temp;
        while (fread(&temp, sizeof(Sensor), 1, file) == 1) {
            if (temp.shifr == shifr) {
                s = temp;
                pos = ftell(file) - sizeof(Sensor);
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
    SubsystemFile(const char* fname, const char* mode = "rb+") {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, mode);
        if (!file) {
            file = fopen(filename, "wb+");
        }
    }

    ~SubsystemFile() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    // добавление подсистемы
    unsigned long addSubsystem(unsigned shifr, const char* name) {
        assert(file);
        fseek(file, 0, SEEK_END);

        Subsystem s;
        s.shifr = shifr;
        strncpy(s.name, name, 40);
        s.name[40] = '\0';

        unsigned long pos = ftell(file);
        fwrite(&s, sizeof(Subsystem), 1, file);
        fflush(file);
        return pos;
    }

    // поиск подсистемы по позиции
    bool getSubsystemByPos(unsigned long pos, Subsystem& s) {
        assert(file);
        fseek(file, pos, SEEK_SET);
        return fread(&s, sizeof(Subsystem), 1, file) == 1;
    }
};

// класс ФАЙЛ_ДЛЯ_СВЯЗЕЙ
class LinkFile {
private:
    FILE* file;
    char* filename;

public:
    LinkFile(const char* fname, const char* mode = "rb+") {
        filename = (char*)malloc(strlen(fname) + 1);
        assert(filename != nullptr);
        strcpy(filename, fname);

        file = fopen(filename, mode);
        if (!file) {
            file = fopen(filename, "wb+");
        }
    }

    ~LinkFile() {
        if (file) fclose(file);
        if (filename) free(filename);
    }

    // добавление связи
    void addLink(unsigned long sensor_pos, unsigned long subsys_pos) {
        assert(file);
        fseek(file, 0, SEEK_END);
        Link l;
        l.sensor_idx = sensor_pos;
        l.subsys_idx = subsys_pos;
        fwrite(&l, sizeof(Link), 1, file);
        fflush(file);
    }

    // поиск подсистемы по позиции датчика
    bool findSubsystemForSensor(unsigned long sensor_pos, unsigned long& subsys_pos) {
        assert(file);
        fseek(file, 0, SEEK_SET);
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
        scanf("%d", &choice);

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
            printf("Датчик добавлен. Позиция: %lu\n", pos);

            unsigned shifrSubsys;
            printf("Введите шифр подсистемы для связи с датчиком: ");
            scanf("%u", &shifrSubsys);

            // ищем подсистему по шифру
            Subsystem sub;
            bool foundSub = false;
            unsigned long posSubsys;
            FILE* f = fopen("SUBSYS.DAT", "rb");
            if (f) {
                while (fread(&sub, sizeof(Subsystem), 1, f) == 1) {
                    if (sub.shifr == shifrSubsys) {
                        posSubsys = ftell(f) - sizeof(Subsystem);
                        foundSub = true;
                        break;
                    }
                }
                fclose(f);
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
            printf("Подсистема добавлена. Позиция: %lu\n", pos);
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
            }
            else {
                printf("Для данного датчика не найдена подсистема.\n");
            }
        }

    } while (choice != 0);

    return 0;
}