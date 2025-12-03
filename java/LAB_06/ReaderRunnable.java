public class ReaderRunnable implements Runnable {
    private final Novel novel;
    private final FifoSemaphore semaphore;

    public ReaderRunnable(Novel novel, FifoSemaphore semaphore) {
        this.novel = novel;
        this.semaphore = semaphore;
    }

    @Override
    public void run() {
        for (int i = 0; i < novel.getPageCounts().size(); i++) {
            try {
                semaphore.waitReader();
                int value = novel.getArrayElement(i);
                System.out.println("Read: " + value + " from position " + i);
                semaphore.toggle();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
