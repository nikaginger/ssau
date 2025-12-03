import java.util.Queue;
import java.util.LinkedList;

public class FifoSemaphore {
    private final Queue<Thread> queue = new LinkedList<>();
    private boolean writerTurn = true;

    public synchronized void waitWriter() throws InterruptedException {
        Thread current = Thread.currentThread();
        queue.add(current);
        while (!writerTurn || queue.peek() != current) {
            wait();
        }
        queue.poll();
    }

    public synchronized void waitReader() throws InterruptedException {
        Thread current = Thread.currentThread();
        queue.add(current);
        while (writerTurn || queue.peek() != current) {
            wait();
        }
        queue.poll();
    }

    public synchronized void toggle() {
        writerTurn = !writerTurn;
        notifyAll();
    }
}