import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;
import java.util.Scanner;

public class Main {
    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        boolean running = true;

        while (running) {
            System.out.println("\nМЕНЮ ЛАБЫ 5:");
            System.out.println("1. Задание 1 (Thread)");
            System.out.println("2. Задание 2 (Runnable + семафор)");
            System.out.println("3. Задание 3 (Синхронизированная оболочка)");
            System.out.println("0. Выход");
            System.out.print("Выберите действие: ");

            int choice = getIntInput();

            switch (choice) {
                case 1 -> runTask1();
                case 2 -> runTask2();
                case 3 -> runTask3();
                case 0 -> {
                    running = false;
                    System.out.println("Работа завершена.");
                }
                default -> System.out.println("Некорректный выбор.");
            }
        }
    }

    private static void runTask1() {
        Novel novel = new Novel("Большой роман", 10, new ArrayList<>(Collections.nCopies(100, 0)));

        WriterThread writer = new WriterThread(novel);
        ReaderThread reader = new ReaderThread(novel);

        writer.setPriority(Thread.MAX_PRIORITY);
        reader.setPriority(Thread.MIN_PRIORITY);

        writer.start();
        reader.start();

        try {
            writer.join();
            reader.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("Задание 1 завершено.");
    }

    private static void runTask2() {
        Novel novel = new Novel("Большой роман", 10, new ArrayList<>(Collections.nCopies(100, 0)));
        FifoSemaphore semaphore = new FifoSemaphore();

        Thread writerThread = new Thread(new WriterRunnable(novel, semaphore));
        Thread readerThread = new Thread(new ReaderRunnable(novel, semaphore));

        writerThread.start();
        readerThread.start();

        try {
            writerThread.join();
            readerThread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("Задание 2 завершено.");
    }

    private static void runTask3() {
        Novel novel = new Novel("Синхр. роман", 5, new ArrayList<>(Collections.nCopies(100, 0)));
        LiteraryWork safeNovel = LiteraryWorkIO.synchronizedLiteraryWork(novel);
        Random rand = new Random();

        Thread writer = new Thread(() -> {
            for (int i = 0; i < 100; i++) {
                int value = rand.nextInt(100) + 1;
                safeNovel.setArrayElement(i, value);
                System.out.println("Write: " + value + " to position " + i);
            }
        });

        Thread reader = new Thread(() -> {
            for (int i = 0; i < 100; i++) {
                int value = safeNovel.getArrayElement(i);
                System.out.println("Read: " + value + " from position " + i);
            }
        });

        writer.start();
        reader.start();

        try {
            writer.join();
            reader.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("Задание 3 завершено.");
    }

    private static int getIntInput() {
        while (true) {
            try {
                return Integer.parseInt(scanner.nextLine().trim());
            } catch (NumberFormatException e) {
                System.out.print("Введите число: ");
            }
        }
    }
}
