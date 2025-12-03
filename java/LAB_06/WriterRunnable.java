public class WriterRunnable implements Runnable {
    private final Novel novel;
    private final FifoSemaphore semaphore;

    public WriterRunnable(Novel novel, FifoSemaphore semaphore) {
        this.novel = novel;
        this.semaphore = semaphore;
    }

    @Override
    public void run() {
        for (int i = 0; i < novel.getPageCounts().size(); i++) {
            try {
                semaphore.waitWriter();
                int value = (int) (Math.random() * 100 + 1);
                novel.setArrayElement(i, value);
                System.out.println("Write: " + value + " to position " + i);
                semaphore.toggle();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
