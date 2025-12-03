public class ReaderThread extends Thread {
    private final LiteraryWork novel;

    public ReaderThread(LiteraryWork novel) {
        this.novel = novel;
    }

    @Override
    public void run() {
        for (int i = 0; i < novel.getPageCounts().size(); i++) {
            synchronized (novel) {
                int pages = novel.getArrayElement(i);
                System.out.println("Read: " + pages + " from position " + i);
            }
            try {
                Thread.sleep(15);
            } catch (InterruptedException ignored) {}
        }
    }
}
