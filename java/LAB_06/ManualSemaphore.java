public class ManualSemaphore {
    private volatile boolean writerTurn = true;

    public synchronized void waitWriter() throws InterruptedException {
        while (!writerTurn) wait();
    }

    public synchronized void waitReader() throws InterruptedException {
        while (writerTurn) wait();
    }

    public synchronized void toggle() {
        writerTurn = !writerTurn;
        notifyAll();
    }
}
