#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <cstdlib>
#include <cstring>

using namespace std;

// КЛАСС ДАТЧИК
class Sensor {
private:
    unsigned shifr;
    string name;

public:
    Sensor(unsigned code, string& n) {
        if (code == 0) throw("Шифр датчика не может быть нулевым");
        if (n.empty()) throw("Название датчика не может быть пустым");
        shifr = code;
        name = n;
        cout << "Создан датчик: " << shifr << " - " << name << endl;
    }

    ~Sensor() {
        cout << "Удален датчик: " << shifr << " - " << name << endl;
    }

    unsigned getCode() {
        return shifr;
    }

    string getName() {
        return name;
    }

    static int findSensorIndex(vector<Sensor*>& sensors, unsigned code) {
        for (int i = 0; i < (int)sensors.size(); i++) {
            if (sensors[i]->getCode() == code) return i;
        }
        return -1;
    }
};

// КЛАСС ПОДСИСТЕМА
class Subsystem {
private:
    unsigned shifr;
    string name;

public:
    Subsystem(unsigned code, const string& n) {
        if (code == 0) throw("Шифр подсистемы не может быть нулевым");
        if (n.empty()) throw("Название подсистемы не может быть пустым");
        shifr = code;
        name = n;
        cout << "Создана подсистема: " << shifr << " - " << name << endl;
    }

    ~Subsystem() {
        cout << "Удалена подсистема: " << shifr << " - " << name << endl;
    }

    unsigned getCode() const {
        return shifr;
    }

    string getName() const {
        return name;
    }

    static int findSubsystemIndex(vector<Subsystem*>& subs, unsigned code) {
        for (int i = 0; i < (int)subs.size(); i++) {
            if (subs[i]->getCode() == code) return i;
        }
        return -1;
    }
};

// СВЯЗЬ ДАТЧИК - ПОДСИСТЕМА
class SensorSubsystemLink {
private:
    int sensorIndex;
    int subsystemIndex;

public:
    SensorSubsystemLink(int sIdx, int ssIdx) {
        if (sIdx < 0) throw("Неверный индекс датчика");
        if (ssIdx < 0) throw("Неверный индекс подсистемы");
        sensorIndex = sIdx;
        subsystemIndex = ssIdx;
        cout << "Создана связь: датчик[" << sensorIndex << "] - подсистема[" << subsystemIndex << "]" << endl;
    }

    ~SensorSubsystemLink() {
        cout << "Удалена связь: датчик[" << sensorIndex
            << "] - подсистема[" << subsystemIndex << "]" << endl;
    }

    int getSensorIndex() const {
        return sensorIndex;
    }

    int getSubsystemIndex() const {
        return subsystemIndex;
    }

    void setSubsystemIndex(int idx) {
        if (idx < 0) throw("Неверный индекс подсистемы");
        subsystemIndex = idx;
    }

    static vector<int> findSubsystemsForSensor(const vector<SensorSubsystemLink*>& links, int sensorIdx) {
        vector<int> result;
        for (auto& L : links) {
            if (L->getSensorIndex() == sensorIdx) result.push_back(L->getSubsystemIndex());
        }
        return result;
    }

    static vector<int> findSensorsForSubsystem(const vector<SensorSubsystemLink*>& links, int subsystemIdx) {
        vector<int> result;
        for (auto& L : links) {
            if (L->getSubsystemIndex() == subsystemIdx) result.push_back(L->getSensorIndex());
        }
        return result;
    }
};

// СОРТИРОВКА ДАТЧИКОВ 
int compareSensors(const void* a, const void* b) {
    Sensor** sa = (Sensor**)a;
    Sensor** sb = (Sensor**)b;
    return (*sa)->getName().compare((*sb)->getName());
}

// ДОБАВЛЕНИЕ ДАТЧИКА
int addSensor(vector<Sensor*>& sensors, unsigned code, string& name) {
    Sensor* s = new Sensor(code, name);
    sensors.push_back(s);
    return sensors.size() - 1;
}

// ДОБАВЛЕНИЕ ПОДСИСТЕМЫ
int addSubsystem(vector<Subsystem*>& subs, unsigned code, string& name) {
    Subsystem* ss = new Subsystem(code, name);
    subs.push_back(ss);
    return subs.size() - 1;
}

//ДОБАВЛЕНИЕ СВЯЗИ
void addLink(vector<SensorSubsystemLink*>& links,
    int sIdx, int ssIdx,
    const vector<Sensor*>& sensors,
    const vector<Subsystem*>& subs)
{
    if (sIdx < 0 || sIdx >= sensors.size()) throw("Датчик не найден");
    if (ssIdx < 0 || ssIdx >= subs.size()) throw("Подсистема не найдена");

    links.push_back(new SensorSubsystemLink(sIdx, ssIdx));
}

// ПРОЦЕДУРА: добавить датчик + подсистема
void addSensorWithSubsystem(vector<Sensor*>& sensors,
    vector<Subsystem*>& subs,
    vector<SensorSubsystemLink*>& links)
{
    unsigned sCode, ssCode;
    string sName, ssName;

    cout << "\nВведите шифр датчика: ";
    cin >> sCode;
    cout << "Введите название датчика: ";
    cin.ignore();
    getline(cin, sName);

    cout << "Введите шифр подсистемы: ";
    cin >> ssCode;
    cout << "Введите название подсистемы: ";
    cin.ignore();
    getline(cin, ssName);

    int sensorIdx = addSensor(sensors, sCode, sName);

    int ssIdx = Subsystem::findSubsystemIndex(subs, ssCode);
    if (ssIdx == -1) ssIdx = addSubsystem(subs, ssCode, ssName);

    addLink(links, sensorIdx, ssIdx, sensors, subs);

    cout << "Датчик и подсистема успешно добавлены\n";
}

// ИЗМЕНИТЬ ПОДСИСТЕМУ ДЛЯ ДАТЧИКА
void changeSensorSubsystem(vector<Sensor*>& sensors,
    vector<Subsystem*>& subs,
    vector<SensorSubsystemLink*>& links)
{
    if (sensors.empty()) {
        cout << "Датчиков нет" << endl;
        return;
    }

    cout << "\nСписок датчиков:\n";
    for (int i = 0; i < sensors.size(); i++) {
        cout << "[" << i << "] " << sensors[i]->getCode() << " - " << sensors[i]->getName() << endl;
    }

    int sIdx;
    cout << "Введите индекс датчика: ";
    cin >> sIdx;

    if (sIdx < 0 || sIdx >= sensors.size()) throw("Неверный индекс датчика");

    unsigned newCode;
    string newName;

    cout << "Введите новый шифр подсистемы: ";
    cin >> newCode;
    cout << "Введите новое имя подсистемы: ";
    cin.ignore();
    getline(cin, newName);

    int ssIdx = Subsystem::findSubsystemIndex(subs, newCode);
    if (ssIdx == -1) ssIdx = addSubsystem(subs, newCode, newName);

    bool found = false;
    for (auto& L : links) {
        if (L->getSensorIndex() == sIdx) {
            L->setSubsystemIndex(ssIdx);
            found = true;
        }
    }

    if (!found) {
        addLink(links, sIdx, ssIdx, sensors, subs);
    }

    cout << "Подсистема изменена\n";
}

// ВЫВЕСТИ ДАТЧИКИ ПО ПОДСИСТЕМЕ 
void displaySensorsBySubsystem(vector<Sensor*>& sensors,
    vector<Subsystem*>& subs,
    vector<SensorSubsystemLink*>& links)
{
    if (subs.empty()) {
        cout << "Подсистем нет\n";
        return;
    }

    unsigned code;
    cout << "\nВведите шифр подсистемы: ";
    cin >> code;

    int ssIdx = Subsystem::findSubsystemIndex(subs, code);
    if (ssIdx == -1) {
        cout << "Подсистема не найдена\n";
        return;
    }

    vector<int> sensorIndices = SensorSubsystemLink::findSensorsForSubsystem(links, ssIdx);

    if (sensorIndices.empty()) {
        cout << "Датчиков нет\n";
        return;
    }

    cout << "\nДатчики подсистемы:\n";
    for (int idx : sensorIndices) {
        cout << sensors[idx]->getCode() << " - " << sensors[idx]->getName() << endl;
    }
}

// ВЫВЕСТИ ВСЕ ДАТЧИКИ С СОРТИРОВКОЙ
void displayAllSensorsSorted(vector<Sensor*>& sensors,
    vector<Subsystem*>& subs,
    vector<SensorSubsystemLink*>& links)
{
    if (sensors.empty()) {
        cout << "Список пуст.\n";
        return;
    }

    vector<Sensor*> sorted = sensors;
    qsort(sorted.data(), sorted.size(), sizeof(Sensor*), compareSensors);

    cout << "\nВсе датчики:\n";
    for (auto& S : sorted) {
        int idx = -1;
        for (int i = 0; i < sensors.size(); i++) {
            if (sensors[i] == S) idx = i;
        }

        cout << S->getCode() << " - " << S->getName() << " : ";

        vector<int> subsIdx = SensorSubsystemLink::findSubsystemsForSensor(links, idx);
        if (subsIdx.empty()) {
            cout << "подсистема не указана\n";
        }
        else {
            for (int s : subsIdx) {
                cout << subs[s]->getName() << " ";
            }
            cout << endl;
        }
    }
}

// ОЧИСТКА ПАМЯТИ
void cleanup(vector<Sensor*>& sensors,
    vector<Subsystem*>& subs,
    vector<SensorSubsystemLink*>& links)
{
    for (auto s : sensors) delete s;
    for (auto ss : subs) delete ss;
    for (auto L : links) delete L;

    sensors.clear();
    subs.clear();
    links.clear();
}

// МЕНЮ
int main() {
    setlocale(LC_ALL, "Russian");

    vector<Sensor*> sensors;
    vector<Subsystem*> subsystems;
    vector<SensorSubsystemLink*> links;

    int choice;
    bool running = true;

    while (running) {
        cout << "\n1. Добавить датчик" << endl;
        cout << "2. Изменить подсистему датчика" << endl;
        cout << "3. Вывести датчики по подсистеме" << endl;
        cout << "4. Вывести все датчики" << endl;
        cout << "0. Выход" << endl;
        cout << "Выберите: ";
        cin >> choice;

        try {
            switch (choice) {
            case 1: addSensorWithSubsystem(sensors, subsystems, links); break;
            case 2: changeSensorSubsystem(sensors, subsystems, links); break;
            case 3: displaySensorsBySubsystem(sensors, subsystems, links); break;
            case 4: displayAllSensorsSorted(sensors, subsystems, links); break;
            case 0: running = false; break;
            default: cout << "Неверный выбор\n";
            }
        }
        catch (const char* err) {
            cerr << "Ошибка: " << err << endl;
        }
        catch (...) {
            cerr << "Неизвестная ошибка." << endl;
        }
    }

    cleanup(sensors, subsystems, links);

    cout << "Работа завершена." << endl;
    return 0;
}
