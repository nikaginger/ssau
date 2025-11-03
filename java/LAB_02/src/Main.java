
public class Main {
    public static void main(String[] args) {
        System.out.println("Лабораторная работа №2\nБреневой Вероники 6301");

        System.out.println("Создание векторов");
        Vector v1 = new Vector(3);

        v1.setCoordinate(0, 3.5);
        v1.setCoordinate(1, 1.2);
        v1.setCoordinate(2, 4.7);
        System.out.println("Вектор v1: " + v1);
        Vector v2 = new Vector(3);
        v2.setCoordinate(0, 1.0);
        v2.setCoordinate(1, 2.0);
        v2.setCoordinate(2, 3.0);
        System.out.println("Вектор v2: " + v2);

        System.out.println("\nМетоды:");

        System.out.println("v1[2] = " + v1.getCoordinate(2));

        System.out.println("Длина v1: " + v1.getLength());

        System.out.println("Минимум в v1: " + v1.findMin());
        System.out.println("Максимум в v1: " + v1.findMax());
        Vector v4 = new Vector(3);
        for (int i = 0; i < v1.getLength(); i++) {
            v4.setCoordinate(i, v1.getCoordinate(i));
        }
        v1.sort();
        System.out.println("v1 после сортировки: " + v1);
        System.out.println("Евклидова норма v2: " + v2.evNorm());


        Vector v3 = new Vector(3);
        for (int i = 0; i < v2.getLength(); i++) {
            v3.setCoordinate(i, v2.getCoordinate(i));
        }
        v3.multiplyVec(2.0);
        System.out.println("v2 * 2 = " + v3);


        Vector sum = Vector.add(v4, v2);
        System.out.println("v1 + v2 = " + sum);


        double dotProd = Vector.scalarProduct(v1, v2);
        System.out.println("v1 ⋅ v2 = " +  dotProd);
        }
    }
