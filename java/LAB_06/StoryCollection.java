import java.io.IOException;
import java.io.OutputStream;
import java.io.Serializable;
import java.io.Writer;
import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Objects;
import java.util.Iterator;

public class StoryCollection implements LiteraryWork, Serializable {
    private static final long serialVersionUID = 1L;

    private String title;
    private int bioPages;
    private List<Integer> stories;

    public StoryCollection() {
        this("Без названия", 0, List.of(25, 30, 40, 35));
    }

    public StoryCollection(String title, int bioPages, List<Integer> stories) {
        if (bioPages < 0)
            throw new InvalidFieldValueException("Количество страниц биографии не может быть отрицательным.");
        if (stories == null || stories.isEmpty())
            throw new InvalidFieldValueException("Список рассказов не может быть пустым.");

        this.title = title;
        this.bioPages = bioPages;
        this.stories = stories;
    }

    @Override
    public String getTitle() {
        return title;
    }

    @Override
    public void setTitle(String title) {
        if (title == null || title.isEmpty())
            throw new InvalidFieldValueException("Название сборника не может быть пустым.");
        this.title = title;
    }

    @Override
    public int getServicePages() {
        return bioPages;
    }

    @Override
    public void setServicePages(int bioPages) {
        if (bioPages < 0)
            throw new InvalidFieldValueException("Количество страниц биографии не может быть отрицательным.");
        this.bioPages = bioPages;
    }

    @Override
    public List<Integer> getPageCounts() {
        return stories;
    }

    @Override
    public void setPageCounts(List<Integer> stories) {
        if (stories == null || stories.isEmpty())
            throw new InvalidFieldValueException("Список рассказов не может быть пустым.");
        this.stories = stories;
    }

    @Override
    public int getArrayElement(int index) {
        if (index < 0 || index >= stories.size()) {
            throw new IndexOutOfBoundsException("Неверный индекс рассказа: " + index);
        }
        return stories.get(index);
    }

    @Override
    public void setArrayElement(int index, int pages) {
        if (index < 0 || index >= stories.size()) {
            throw new IndexOutOfBoundsException("Неверный индекс рассказа: " + index);
        }
        if (pages <= 0) {
            throw new InvalidFieldValueException("Количество страниц рассказа должно быть положительным");
        }
        stories.set(index, pages);
    }

    @Override
    public int calculateUsefulPages() throws InvalidBookDataException {
        int total = stories.stream().mapToInt(Integer::intValue).sum();
        if (total < bioPages)
            throw new InvalidBookDataException("Количество страниц биографии превышает общую длину сборника.");
        return total - bioPages;
    }

    @Override
    public String toString() {
        return "Сборник рассказов \"" + title + "\", рассказы: " + stories +
                ", страницы биографии: " + bioPages;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o)
            return true;
        if (!(o instanceof StoryCollection))
            return false;
        StoryCollection that = (StoryCollection) o;
        return bioPages == that.bioPages &&
                Objects.equals(title, that.title) &&
                Objects.equals(stories, that.stories);
    }

    @Override
    public int hashCode() {
        return Objects.hash(title, bioPages, stories);
    }

    // ЛАБА 4 тут
    @Override
    public void output(OutputStream out) throws IOException {
        String data = "STORY;" + title + ";" + bioPages + ";" + stories.toString() + "\n";
        out.write(data.getBytes(StandardCharsets.UTF_8));
    }

    @Override
    public void write(Writer out) throws IOException {
        out.write("STORY " + title + " " + bioPages);
        for (Integer pages : stories) {
            out.write(" " + pages);
        }
        out.write("\n");
    }

    @Override
    public int compareTo(LiteraryWork other) {
        int myUseful;
        int otherUseful;
        try {
            myUseful = this.calculateUsefulPages();
        } catch (InvalidBookDataException e) {
            myUseful = Integer.MIN_VALUE;
        }
        try {
            otherUseful = other.calculateUsefulPages();
        } catch (InvalidBookDataException e) {
            otherUseful = Integer.MIN_VALUE;
        }
        return Integer.compare(myUseful, otherUseful);
    }

    @Override
    public Iterator<Integer> iterator() {
        return new StoryIterator();
    }

    private class StoryIterator implements Iterator<Integer> {
        private int index = 0;

        @Override
        public boolean hasNext() {
            return index < stories.size();
        }

        @Override
        public Integer next() {
            return stories.get(index++);
        }
    }
}
