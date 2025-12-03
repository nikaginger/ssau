import java.util.*;
import java.util.stream.Collectors;

public class Main3 {
    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        List<LiteraryWork> works = new ArrayList<>();
        boolean running = true;

        while (running) {
            System.out.println("\nМЕНЮ:");
            System.out.println("1. Добавить роман");
            System.out.println("2. Добавить сборник рассказов");
            System.out.println("3. Показать все произведения");
            System.out.println("4. Сгруппировать по количеству полезных страниц");
            System.out.println("5. Разделить по типу (романы / сборники)");
            System.out.println("0. Выход");
            System.out.print("Выберите действие: ");

            int choice = getIntInput();

            switch (choice) {
                case 1 -> works.add(createNovel());
                case 2 -> works.add(createStoryCollection());
                case 3 -> printAll(works);
                case 4 -> groupByUsefulPages(works);
                case 5 -> splitByType(works);
                case 0 -> {
                    running = false;
                    System.out.println("Работа завершена. До свидания!");
                }
                default -> System.out.println("Некорректный выбор. Повторите ввод.");
            }
        }
    }

    private static int getIntInput() {
        while (true) {
            try {
                String input = scanner.nextLine().trim();
                if (input.isEmpty()) {
                    System.out.print("Введите число: ");
                    continue;
                }
                return Integer.parseInt(input);
            } catch (NumberFormatException e) {
                System.out.print("Ошибка ввода. Введите число: ");
            }
        }
    }

    private static List<Integer> getIntList() {
        while (true) {
            try {
                String input = scanner.nextLine().trim();
                if (input.isEmpty())
                    throw new IllegalArgumentException("Список не может быть пустым.");
                return Arrays.stream(input.split("\\s+"))
                        .map(Integer::parseInt)
                        .collect(Collectors.toList());
            } catch (NumberFormatException e) {
                System.out.print("Ошибка: вводите только числа через пробел: ");
            } catch (IllegalArgumentException e) {
                System.out.print(e.getMessage() + " Повторите ввод: ");
            }
        }
    }

    private static LiteraryWork createNovel() {
        System.out.print("Введите название романа (Enter — по умолчанию): ");
        String title = scanner.nextLine().trim();
        if (title.isEmpty())
            return new Novel();

        System.out.print("Введите количество страниц с примечаниями: ");
        int notes = getIntInput();

        System.out.print("Введите количество страниц в главах (через пробел): ");
        List<Integer> chapters = getIntList();

        try {
            return new Novel(title, notes, chapters);
        } catch (InvalidFieldValueException e) {
            System.out.println("Ошибка: " + e.getMessage() + " Создан роман по умолчанию.");
            return new Novel();
        }
    }

    private static LiteraryWork createStoryCollection() {
        System.out.print("Введите название сборника рассказов (Enter — по умолчанию): ");
        String title = scanner.nextLine().trim();
        if (title.isEmpty())
            return new StoryCollection();

        System.out.print("Введите количество страниц биографии: ");
        int bio = getIntInput();

        System.out.print("Введите количество страниц в рассказах (через пробел): ");
        List<Integer> stories = getIntList();

        try {
            return new StoryCollection(title, bio, stories);
        } catch (InvalidFieldValueException e) {
            System.out.println("Ошибка: " + e.getMessage() + " Создан сборник по умолчанию.");
            return new StoryCollection();
        }
    }

    private static void printAll(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Список произведений пуст.");
            return;
        }
        System.out.println("\nВСЕ ПРОИЗВЕДЕНИЯ:");
        for (int i = 0; i < works.size(); i++) {
            System.out.println((i + 1) + ".) " + works.get(i));
        }
    }

    // остатки былой роскоши ЛАБЫ 3
    private static void groupByUsefulPages(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Список пуст. Нечего группировать.");
            return;
        }

        Map<Integer, List<LiteraryWork>> groups = new HashMap<>();
        for (LiteraryWork w : works) {
            int useful;
            try {
                useful = w.calculateUsefulPages();
            } catch (InvalidBookDataException e) {
                System.out.println("Ошибка при расчёте: " + e.getMessage());
                continue;
            }
            if (!groups.containsKey(useful)) {
                groups.put(useful, new ArrayList<>());
            }
            groups.get(useful).add(w);
        }

        System.out.println("\nГРУППЫ ПО КОЛИЧЕСТВУ ПОЛЕЗНЫХ СТРАНИЦ:");
        for (Map.Entry<Integer, List<LiteraryWork>> entry : groups.entrySet()) {
            System.out.println("Полезные страницы: " + entry.getKey());
            for (LiteraryWork w : entry.getValue()) {
                System.out.println("   " + w);
            }
        }
    }

    private static void splitByType(List<LiteraryWork> works) {
        List<Novel> novels = new ArrayList<>();
        List<StoryCollection> collections = new ArrayList<>();

        for (LiteraryWork w : works) {
            if (w instanceof Novel)
                novels.add((Novel) w);
            else if (w instanceof StoryCollection)
                collections.add((StoryCollection) w);
        }

        System.out.println("\nРОМАНЫ:");
        if (novels.isEmpty())
            System.out.println("Нет романов.");
        else
            novels.forEach(System.out::println);

        System.out.println("\nСБОРНИКИ РАССКАЗОВ:");
        if (collections.isEmpty())
            System.out.println("Нет сборников рассказов.");
        else
            collections.forEach(System.out::println);
    }
}
