import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class LiteraryWorkIO {

    // синхронизированный объект
    public static LiteraryWork synchronizedLiteraryWork(LiteraryWork work) {
        return new SynchronizedLiteraryWork(work);
    }

    // запись в байтовый поток
    public static void outputLiteraryWork(LiteraryWork work, OutputStream out) throws IOException {
        if (work == null || out == null)
            return;
        work.output(out);
    }

    // чтение ВСЕГО списка из байтового потока
    public static List<LiteraryWork> inputAllLiteraryWorks(InputStream in) throws IOException {
        if (in == null)
            return new ArrayList<>();
        BufferedReader reader = new BufferedReader(new InputStreamReader(in, StandardCharsets.UTF_8));

        List<LiteraryWork> works = new ArrayList<>();
        String line;
        while ((line = reader.readLine()) != null) {
            if (line.isBlank())
                continue;

            String[] parts = line.split(";", 4);
            String type = parts[0];
            String title = parts[1];
            int servicePages = Integer.parseInt(parts[2]);

            List<Integer> pages = new ArrayList<>();
            String numbers = parts[3].replaceAll("[\\[\\]\\s]", "");
            if (!numbers.isEmpty()) {
                for (String num : numbers.split(",")) {
                    pages.add(Integer.parseInt(num));
                }
            }

            if (type.equals("NOVEL"))
                works.add(new Novel(title, servicePages, pages));
            else if (type.equals("STORY"))
                works.add(new StoryCollection(title, servicePages, pages));
        }
        return works;
    }

    // запись в символьный поток
    public static void writeLiteraryWork(LiteraryWork work, Writer out) throws IOException {
        if (work == null || out == null)
            return;
        work.write(out);
    }

    // чтение ВСЕГО списка из символьного потока
    public static List<LiteraryWork> readAllLiteraryWorks(Reader in) throws IOException {
        if (in == null)
            return new ArrayList<>();
        BufferedReader reader = new BufferedReader(in);

        List<LiteraryWork> works = new ArrayList<>();
        String line;
        while ((line = reader.readLine()) != null) {
            if (line.isBlank())
                continue;

            String[] parts = line.split("\\s+");
            if (parts.length < 3)
                continue;

            String type = parts[0];
            String title = parts[1];
            int servicePages = Integer.parseInt(parts[2]);

            List<Integer> pages = new ArrayList<>();
            for (int i = 3; i < parts.length; i++) {
                pages.add(Integer.parseInt(parts[i]));
            }

            if (type.equals("NOVEL")) {
                works.add(new Novel(title, servicePages, pages));
            } else if (type.equals("STORY")) {
                works.add(new StoryCollection(title, servicePages, pages));
            }
        }
        return works;
    }

    // сериализация всего списка
    public static void serializeAllLiteraryWorks(List<LiteraryWork> works, OutputStream out) throws IOException {
        ObjectOutputStream oos = new ObjectOutputStream(out);
        oos.writeObject(works);
        oos.close();
    }

    // десериализация всего списка
    public static List<LiteraryWork> deserializeAllLiteraryWorks(InputStream in)
            throws IOException, ClassNotFoundException {
        ObjectInputStream ois = new ObjectInputStream(in);
        Object obj = ois.readObject();
        ois.close();

        if (obj instanceof List<?>) {
            List<?> rawList = (List<?>) obj;

            List<LiteraryWork> works = new ArrayList<>();
            for (Object item : rawList) {
                if (item instanceof LiteraryWork) {
                    works.add((LiteraryWork) item);
                } else {
                    throw new IOException("Найден элемент, который не является LiteraryWork: " + item.getClass());
                }
            }
            return works;
        } else {
            throw new IOException("Файл не содержит список объектов LiteraryWork.");
        }
    }

    // метод десереализации с некрасивым приведением типов
    @SuppressWarnings("unchecked")
    public static List<LiteraryWork> deserializeLiteraryWorks2(InputStream in)
            throws IOException, ClassNotFoundException {
        ObjectInputStream ois = new ObjectInputStream(in);
        List<LiteraryWork> works = (List<LiteraryWork>) ois.readObject();
        ois.close();
        return works;
    }

    // форматированный вывод
    public static void writeFormatLiteraryWork(LiteraryWork work, Writer out) throws IOException {
        if (work == null || out == null)
            return;

        out.write("Название: " + work.getTitle() + "\n");
        out.write("Служебные страницы: " + work.getServicePages() + "\n");

        out.write("Страницы: ");
        List<Integer> pages = work.getPageCounts();
        for (int i = 0; i < pages.size(); i++) {
            out.write(pages.get(i).toString());
            if (i < pages.size() - 1)
                out.write(", ");
        }
        out.write("\n");
        out.flush();
    }

    // форматированный ввод
    public static LiteraryWork readFormatLiteraryWork(Scanner in) {
        if (in == null)
            return null;

        String title = in.nextLine().replace("Название: ", "").trim();
        int servicePages = Integer.parseInt(in.nextLine().replace("Служебные страницы: ", "").trim());

        String pagesLine = in.nextLine().replace("Страницы: ", "").trim();
        List<Integer> pages = new ArrayList<>();
        for (String n : pagesLine.split(","))
            if (!n.isBlank())
                pages.add(Integer.parseInt(n.trim()));

        return new StoryCollection(title, servicePages, pages);
    }

    // чтение из байтового и символьного потоков по одному LiteraryWork (переделать
    // позже для удобства)
    public static LiteraryWork inputLiteraryWork(InputStream in) throws IOException {
        if (in == null)
            return null;

        BufferedReader reader = new BufferedReader(new InputStreamReader(in, StandardCharsets.UTF_8));
        String line = reader.readLine();
        if (line == null || line.isBlank())
            return null;

        String[] parts = line.split(";");
        String title = parts[0];
        int servicePages = Integer.parseInt(parts[1]);

        String numbers = parts[2].replaceAll("[\\[\\]\\s]", "");
        List<Integer> pages = new ArrayList<>();
        if (!numbers.isEmpty()) {
            for (String num : numbers.split(","))
                pages.add(Integer.parseInt(num));
        }

        return new StoryCollection(title, servicePages, pages);
    }

    public static LiteraryWork readLiteraryWork(Reader in) throws IOException {
        if (in == null)
            return null;

        BufferedReader reader = new BufferedReader(in);
        String line = reader.readLine();
        if (line == null || line.isBlank())
            return null;

        // line выглядит так: "title number 1 2 3"
        String[] parts = line.split("\\s+");
        String title = parts[0];
        int servicePages = Integer.parseInt(parts[1]);

        List<Integer> pages = new ArrayList<>();
        for (int i = 2; i < parts.length; i++)
            pages.add(Integer.parseInt(parts[i]));

        return new StoryCollection(title, servicePages, pages);
    }
}
