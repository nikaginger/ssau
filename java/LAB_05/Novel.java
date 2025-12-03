import java.io.IOException;
import java.io.OutputStream;
import java.io.Serializable;
import java.io.Writer;
import java.nio.charset.StandardCharsets;
import java.util.List;
import java.util.Objects;

public class Novel implements LiteraryWork, Serializable {
    private static final long serialVersionUID = 1L;

    private String title;
    private int notesPages;
    private List<Integer> chapters;

    public Novel() {
        this("Без названия", 0, List.of(120, 150, 180));
    }

    public Novel(String title, int notesPages, List<Integer> chapters) {
        if (notesPages < 0)
            throw new InvalidFieldValueException("Количество страниц примечаний не может быть отрицательным.");
        if (chapters == null || chapters.isEmpty())
            throw new InvalidFieldValueException("Список глав не может быть пустым.");

        this.title = title;
        this.notesPages = notesPages;
        this.chapters = chapters;
    }

    @Override
    public String getTitle() {
        return title;
    }

    @Override
    public void setTitle(String title) {
        if (title == null || title.isEmpty())
            throw new InvalidFieldValueException("Название романа не может быть пустым.");
        this.title = title;
    }

    @Override
    public int getServicePages() {
        return notesPages;
    }

    @Override
    public void setServicePages(int notesPages) {
        if (notesPages < 0)
            throw new InvalidFieldValueException("Количество страниц примечаний не может быть отрицательным.");
        this.notesPages = notesPages;
    }

    @Override
    public List<Integer> getPageCounts() {
        return chapters;
    }

    @Override
    public void setPageCounts(List<Integer> chapters) {
        if (chapters == null || chapters.isEmpty())
            throw new InvalidFieldValueException("Список глав не может быть пустым.");
        this.chapters = chapters;
    }

    @Override
    public int getArrayElement(int index) {
        if (index < 0 || index >= chapters.size()) {
            throw new IndexOutOfBoundsException("Неверный индекс главы: " + index);
        }
        return chapters.get(index);
    }

    @Override
    public void setArrayElement(int index, int pages) {
        if (index < 0 || index >= chapters.size()) {
            throw new IndexOutOfBoundsException("Неверный индекс главы: " + index);
        }
        if (pages <= 0) {
            throw new InvalidFieldValueException("Количество страниц главы должно быть положительным");
        }
        chapters.set(index, pages);
    }

    @Override
    public int calculateUsefulPages() throws InvalidBookDataException {
        int total = chapters.stream().mapToInt(Integer::intValue).sum();
        if (total < notesPages)
            throw new InvalidBookDataException("Количество страниц примечаний превышает общую длину романа.");
        return total - notesPages;
    }

    @Override
    public String toString() {
        return "Роман \"" + title + "\", главы: " + chapters +
                ", страницы примечаний: " + notesPages;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o)
            return true;
        if (!(o instanceof Novel))
            return false;
        Novel novel = (Novel) o;
        return notesPages == novel.notesPages &&
                Objects.equals(title, novel.title) &&
                Objects.equals(chapters, novel.chapters);
    }

    @Override
    public int hashCode() {
        return Objects.hash(title, notesPages, chapters);
    }

    // ЛАБА 4 тут

    @Override
    public void output(OutputStream out) throws IOException {
        // добавляем тип в начало строки
        String data = "NOVEL;" + title + ";" + notesPages + ";" + chapters.toString() + "\n";
        out.write(data.getBytes(StandardCharsets.UTF_8));
    }

    @Override
    public void write(Writer out) throws IOException {
        out.write("NOVEL " + title + " " + notesPages);
        for (Integer pages : chapters) {
            out.write(" " + pages);
        }
        out.write("\n");
    }
}