import java.io.PrintStream;
import java.util.*;

public class Main6 {

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {

        List<LiteraryWork> works = new ArrayList<>();
        boolean running = true;

        while (running) {
            System.out.println("\n ЛАБОРАТОРНАЯ 6");
            System.out.println("1. Добавить роман");
            System.out.println("2. Добавить сборник рассказов");
            System.out.println("3. Показать все произведения");
            System.out.println("4. Тест сортировки (задание 1)");
            System.out.println("5. Тест сортировки с компараторами (задание 2)");
            System.out.println("6. Тест итераторов (задание 3)");
            System.out.println("7. Тест неизменяемого декоратора (задание 4)");
            System.out.println("0. Выход");
            System.out.print("Выбор: ");

            int choice = getInt();

            switch (choice) {
                case 1 -> works.add(createNovel());
                case 2 -> works.add(createStoryCollection());
                case 3 -> printAll(works);
                case 4 -> testSort(works);
                case 5 -> testSortWithComparators(works);
                case 6 -> testIterators(works);
                case 7 -> testUnmodifiable(works);
                case 0 -> {
                    running = false;
                    System.out.println("Выход.");
                }
                default -> System.out.println("Неверный ввод.");
            }
        }
    }

    // задание 1

    private static void testSort(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Сортировать нечего — список пуст.");
        } else {
            System.out.println("\nДо сортировки:");
            PrintStream printer = System.out;
            Objects.requireNonNull(printer);
            works.forEach(printer::println);

            LiteraryWorkUtils.sort(works);

            System.out.println("\nПосле сортировки (по возрастанию бизнес-метода):");
            printer = System.out;
            Objects.requireNonNull(printer);
            works.forEach(printer::println);
        }
    }

    // задание 2

    private static void testSortWithComparators(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Сортировать нечего — список пуст.");
        } else {
            System.out.println("\nДо сортировки:");
            PrintStream printer = System.out;
            Objects.requireNonNull(printer);
            works.forEach(printer::println);

            works.sort(new BusinessDescComparator());
            System.out.println("\nПосле сортировки по убыванию бизнес-метода:");
            printer = System.out;
            Objects.requireNonNull(printer);
            works.forEach(printer::println);

            works.sort(new PagesAscComparator());
            System.out.println("\nПосле сортировки по возрастанию дополнительного поля:");
            printer = System.out;
            Objects.requireNonNull(printer);
            works.forEach(printer::println);
        }
    }

    // задание 3

    private static void testIterators(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Список пуст.");
        } else {
            System.out.println("\n=== Итератор через while ===");
            Iterator<LiteraryWork> workIterator = works.iterator();

            while (workIterator.hasNext()) {
                LiteraryWork work = workIterator.next();
                Iterator<Integer> pagesIterator = work.iterator();
                System.out.print(work + " => ");

                while (pagesIterator.hasNext()) {
                    System.out.print(pagesIterator.next() + " ");
                }

                System.out.println();
            }

            System.out.println("\n=== Итератор через for-each ===");
            for (LiteraryWork work : works) {
                System.out.print(work + " => ");
                for (int page : work) {
                    System.out.print(page + " ");
                }
                System.out.println();
            }
        }
    }

    // задание 4

    private static void testUnmodifiable(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Список пуст.");
            return;
        }

        LiteraryWork first = works.get(0);
        LiteraryWork unmod = LiteraryWorkUtils.unmodifiable(first);

        System.out.println("Оригинал: " + first);
        System.out.println("Декоратор: " + unmod);

        try {
            unmod.setPageCounts(List.of(1, 2, 3));
        } catch (UnsupportedOperationException e) {
            System.out.println("Попытка изменения вызвала исключение: " + e.getMessage());
        }
    }

    // вспомогательные методы

    private static int getInt() {
        while (true) {
            try {
                return Integer.parseInt(scanner.nextLine().trim());
            } catch (Exception e) {
                System.out.print("Введите число: ");
            }
        }
    }

    private static List<Integer> getIntList() {
        while (true) {
            try {
                String[] arr = scanner.nextLine().trim().split("\\s+");
                List<Integer> list = new ArrayList<>();
                for (String s : arr)
                    list.add(Integer.parseInt(s));
                return list;
            } catch (Exception e) {
                System.out.print("Ошибка! Повторите ввод: ");
            }
        }
    }

    private static LiteraryWork createNovel() {
        LiteraryWorkUtils.setLiteraryWorkFactory(new NovelFactory());
        LiteraryWork w = LiteraryWorkUtils.createInstance();

        System.out.print("Название романа: ");
        String title = scanner.nextLine().trim();
        w.setTitle(title);

        System.out.print("Страницы примечаний: ");
        w.setServicePages(getInt());

        System.out.print("Страницы глав (через пробел): ");
        w.setPageCounts(getIntList());

        return w;
    }

    private static LiteraryWork createStoryCollection() {
        LiteraryWorkUtils.setLiteraryWorkFactory(new StoryCollectionFactory());
        LiteraryWork w = LiteraryWorkUtils.createInstance();

        System.out.print("Название сборника: ");
        w.setTitle(scanner.nextLine().trim());

        System.out.print("Страницы биографии: ");
        w.setServicePages(getInt());

        System.out.print("Страницы рассказов (через пробел): ");
        w.setPageCounts(getIntList());

        return w;
    }

    private static void printAll(List<LiteraryWork> works) {
        if (works.isEmpty()) {
            System.out.println("Список пуст.");
        } else {
            System.out.println("\nТЕКУЩИЕ ПРОИЗВЕДЕНИЯ:");
            int index = 1;
            for (LiteraryWork work : works) {
                System.out.println(index++ + ". " + work);
            }
        }
    }
}
