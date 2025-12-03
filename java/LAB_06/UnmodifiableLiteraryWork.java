import java.io.IOException;
import java.io.OutputStream;
import java.io.Writer;
import java.util.Iterator;
import java.util.List;

public class UnmodifiableLiteraryWork implements LiteraryWork {
    private final LiteraryWork inner;

    public UnmodifiableLiteraryWork(LiteraryWork inner) {
        this.inner = inner;
    }

    @Override
    public String getTitle() {
        return inner.getTitle();
    }

    @Override
    public int getServicePages() {
        return inner.getServicePages();
    }

    @Override
    public List<Integer> getPageCounts() {
        return List.copyOf(inner.getPageCounts());
    }

    @Override
    public int getArrayElement(int index) {
        return inner.getArrayElement(index);
    }

    @Override
    public int calculateUsefulPages() throws InvalidBookDataException {
        return inner.calculateUsefulPages();
    }

    @Override
    public void output(OutputStream out) throws IOException {
        inner.output(out);
    }

    @Override
    public void write(Writer out) throws IOException {
        inner.write(out);
    }

    @Override
    public Iterator<Integer> iterator() {
        return new Iterator<>() {
            private final Iterator<Integer> it = inner.iterator();

            @Override
            public boolean hasNext() {
                return it.hasNext();
            }

            @Override
            public Integer next() {
                return it.next();
            }

            @Override
            public void remove() {
                throw new UnsupportedOperationException("Объект неизменяемый");
            }
        };
    }

    @Override
    public int compareTo(LiteraryWork o) {
        return inner.compareTo(o);
    }

    @Override
    public void setTitle(String title) {
        throw new UnsupportedOperationException("Объект неизменяемый");
    }

    @Override
    public void setServicePages(int servicePages) {
        throw new UnsupportedOperationException("Объект неизменяемый");
    }

    @Override
    public void setPageCounts(List<Integer> pageCounts) {
        throw new UnsupportedOperationException("Объект неизменяемый");
    }

    @Override
    public void setArrayElement(int index, int pages) {
        throw new UnsupportedOperationException("Объект неизменяемый");
    }

    @Override
    public String toString() {
        return inner.toString() + " [UNMODIFIABLE]";
    }
}
