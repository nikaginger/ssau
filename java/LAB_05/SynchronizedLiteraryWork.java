import java.util.List;
import java.util.ArrayList;
import java.io.OutputStream;
import java.io.Writer;
import java.io.IOException;

public class SynchronizedLiteraryWork implements LiteraryWork {
    private final LiteraryWork original;

    public SynchronizedLiteraryWork(LiteraryWork original) {
        if (original == null) throw new IllegalArgumentException("Original cannot be null");
        this.original = original;
    }

    @Override
    public synchronized String getTitle() {
        return original.getTitle();
    }

    @Override
    public synchronized void setTitle(String title) {
        original.setTitle(title);
    }

    @Override
    public synchronized int getServicePages() {
        return original.getServicePages();
    }

    @Override
    public synchronized void setServicePages(int servicePages) {
        original.setServicePages(servicePages);
    }

    @Override
    public synchronized List<Integer> getPageCounts() {
        return new ArrayList<>(original.getPageCounts()); // копия для безопасности
    }

    @Override
    public synchronized void setPageCounts(List<Integer> pageCounts) {
        original.setPageCounts(pageCounts);
    }

    @Override
    public synchronized int getArrayElement(int index) {
        return original.getArrayElement(index);
    }

    @Override
    public synchronized void setArrayElement(int index, int pages) {
        original.setArrayElement(index, pages);
    }

    @Override
    public synchronized int calculateUsefulPages() throws InvalidBookDataException {
        return original.calculateUsefulPages();
    }

    @Override
    public synchronized void output(OutputStream out) throws IOException {
        original.output(out);
    }

    @Override
    public synchronized void write(Writer out) throws IOException {
        original.write(out);
    }
}
