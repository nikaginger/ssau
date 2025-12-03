import java.util.Random;

public class WriterThread extends Thread {
    private final LiteraryWork novel;
    private final Random random = new Random();

    public WriterThread(LiteraryWork novel) {
        this.novel = novel;
    }

    @Override
    public void run() {
        for (int i = 0; i < novel.getPageCounts().size(); i++) {
            int pages = random.nextInt(50) + 1;
            synchronized (novel) {
                novel.setArrayElement(i, pages);
                System.out.println("Write: " + pages + " to position " + i);
            }
            try {
                Thread.sleep(10);
            } catch (InterruptedException ignored) {}
        }
    }
}
