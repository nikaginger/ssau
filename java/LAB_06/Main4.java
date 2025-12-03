import java.io.*;
import java.util.*;

public class Main4 {
    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        List<LiteraryWork> works = new ArrayList<>();
        boolean running = true;

        while (running) {
            System.out.println("\nМЕНЮ:");
            System.out.println("1. Добавить роман");
            System.out.println("2. Добавить сборник рассказов");
            System.out.println("3. Показать все произведения");
            System.out.println("4. Тест байтового ввода/вывода");
            System.out.println("5. Тест символьного ввода/вывода");
            System.out.println("6. Тест сериализации/десериализации");
            System.out.println("7. Тест форматного ввода/вывода");
            System.out.println("0. Выход");
            System.out.print("Выберите действие: ");

            int choice = getIntInput();

            switch (choice) {
                case 1 -> works.add(createNovel());
                case 2 -> works.add(createStoryCollection());
                case 3 -> printAll(works);
                case 4 -> testByteIO(works);
                case 5 -> testCharIO(works);
                case 6 -> testSerialization(works);
                case 7 -> testFormattedIO(works);
                case 0 -> {
                    running = false;
                    System.out.println("Работа завершена.");
                }
                default -> System.out.println("Некорректный выбор.");
            }
        }
    }

    // тест байтового ввода/вывода
    private static void testByteIO(List<LiteraryWork> works) {
        File file = new File("byte_data.bin");

        // запись
        try (OutputStream out = new FileOutputStream(file)) {
            for (LiteraryWork w : works) {
                LiteraryWorkIO.outputLiteraryWork(w, out);
            }
            System.out.println("Байтовая запись завершена.");
        } catch (IOException e) {
            System.out.println("Ошибка записи: " + e.getMessage());
        }

        // чтение всех объектов
        try (InputStream in = new FileInputStream(file)) {
            List<LiteraryWork> readWorks = LiteraryWorkIO.inputAllLiteraryWorks(in);
            System.out.println("Байтовое чтение завершено:");
            readWorks.forEach(System.out::println);
        } catch (IOException e) {
            System.out.println("Ошибка чтения: " + e.getMessage());
        }
    }

    // тест символьного ввода/вывода
    private static void testCharIO(List<LiteraryWork> works) {
        File file = new File("text_data.txt");

        // запись
        try (Writer out = new FileWriter(file)) {
            for (LiteraryWork w : works) {
                LiteraryWorkIO.writeLiteraryWork(w, out);
            }
            System.out.println("Текстовая запись завершена.");
        } catch (IOException e) {
            System.out.println("Ошибка записи: " + e.getMessage());
        }

        // чтение всех объектов
        try (Reader in = new FileReader(file)) {
            List<LiteraryWork> readWorks = LiteraryWorkIO.readAllLiteraryWorks(in);
            System.out.println("Текстовое чтение завершено:");
            readWorks.forEach(System.out::println);
        } catch (IOException e) {
            System.out.println("Ошибка чтения: " + e.getMessage());
        }
    }

    // тест сериализации
    private static void testSerialization(List<LiteraryWork> works) {
        File file = new File("serialized_data.dat");

        try {
            LiteraryWorkIO.serializeAllLiteraryWorks(works, new FileOutputStream(file));
            System.out.println("Сериализация завершена.");

            List<LiteraryWork> readWorks = LiteraryWorkIO.deserializeAllLiteraryWorks(new FileInputStream(file));
            System.out.println("Десериализация завершена.");

            for (LiteraryWork w : readWorks) {
                System.out.println(w);
            }
        } catch (IOException | ClassNotFoundException e) {
            System.out.println("Ошибка: " + e.getMessage());
        }
    }

    // тест форматного ввода/вывода
    private static void testFormattedIO(List<LiteraryWork> works) {
        File file = new File("formatted_data.txt");
        try (Writer out = new FileWriter(file)) {
            for (LiteraryWork w : works) {
                LiteraryWorkIO.writeFormatLiteraryWork(w, out);
            }
            System.out.println("Форматная запись завершена.");
        } catch (IOException e) {
            System.out.println("Ошибка записи: " + e.getMessage());
        }

        List<LiteraryWork> readWorks = new ArrayList<>();
        try (Scanner sc = new Scanner(file)) {
            while (sc.hasNextLine()) {
                readWorks.add(LiteraryWorkIO.readFormatLiteraryWork(sc));
            }
            System.out.println("Форматное чтение завершено:");
            readWorks.forEach(System.out::println);
        } catch (Exception e) {
            System.out.println("Ошибка чтения: " + e.getMessage());
        }
    }

    // вспомогательные методы (из старого Main)
    private static int getIntInput() {
        while (true) {
            try {
                return Integer.parseInt(scanner.nextLine().trim());
            } catch (NumberFormatException e) {
                System.out.print("Введите число: ");
            }
        }
    }

    private static List<Integer> getIntList() {
        while (true) {
            try {
                String input = scanner.nextLine().trim();
                if (input.isEmpty())
                    throw new IllegalArgumentException("Список не может быть пустым.");
                String[] parts = input.split("\\s+");
                List<Integer> result = new ArrayList<>();
                for (String p : parts)
                    result.add(Integer.parseInt(p));
                return result;
            } catch (Exception e) {
                System.out.print("Ошибка, повторите ввод: ");
            }
        }
    }

    private static LiteraryWork createNovel() {
        System.out.print("Введите название романа: ");
        String title = scanner.nextLine().trim();
        if (title.isEmpty())
            return new Novel();

        System.out.print("Введите страницы примечаний: ");
        int notes = getIntInput();

        System.out.print("Введите страницы глав (через пробел): ");
        List<Integer> chapters = getIntList();

        return new Novel(title, notes, chapters);
    }

    private static LiteraryWork createStoryCollection() {
        System.out.print("Введите название сборника: ");
        String title = scanner.nextLine().trim();
        if (title.isEmpty())
            return new StoryCollection();

        System.out.print("Введите страницы биографии: ");
        int bio = getIntInput();

        System.out.print("Введите страницы рассказов (через пробел): ");
        List<Integer> stories = getIntList();

        return new StoryCollection(title, bio, stories);
    }

    private static void printAll(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Список пуст.");
            return;
        }
        System.out.println("\nВСЕ ПРОИЗВЕДЕНИЯ:");
        for (int i = 0; i < works.size(); i++) {
            System.out.println((i + 1) + ". " + works.get(i));
        }
    }
}