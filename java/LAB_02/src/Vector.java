import java.util.Arrays;

public class Vector {
    private double[] coordinates;
    public Vector(int length){
        if (length<=0){
            throw new IllegalArgumentException("Длина вектора должна быть положительной");
        }
        this.coordinates=new double[length];
    }

    public void setCoordinate(int index, double value){
        if (index<0|| index>=coordinates.length){
            throw new IllegalArgumentException("Индекс выходит за пределы вектора");
        }
        coordinates[index] = value;
    }

    public double getCoordinate(int index){
        if (index<0|| index>=coordinates.length){
            throw new IllegalArgumentException("Индекс выходит за пределы вектора");
        }
        return coordinates[index];
    }
    
    public int getLength(){
        return coordinates.length;
    }

    public double findMax(){
        if (coordinates.length == 0) {
            throw new IllegalStateException("Вектор пустой");
        }
        double max=coordinates[0];
        for (int i=1; i<coordinates.length;i++){
            if (coordinates[i]>max){
                max=coordinates[i];
            }
        }
        return max;
    }

    public double findMin(){
        if (coordinates.length == 0) {
            throw new IllegalStateException("Вектор пустой");
        }
        double min=coordinates[0];
        for (int i=1; i<coordinates.length;i++){
            if (coordinates[i]<min){
                min=coordinates[i];
            }
        }
        return min;
    }

    public void sort(){
        Arrays.sort(coordinates);
    }

    public double evNorm(){
        double sum=0.0;
        for (double coordinate: coordinates){
            sum+=coordinate*coordinate;
        }
        return Math.sqrt(sum);
    }

    public void multiplyVec(double x){
        for (int i=0; i<coordinates.length;i++){
            coordinates[i]*=x;
        }
    }

    public static Vector add(Vector v1, Vector v2){
        if (v1.getLength() != v2.getLength()) {
            throw new IllegalArgumentException("Векторы должны быть одинаковой длины");
        }
        Vector result= new Vector(v1.getLength());
        for (int i=0; i<v1.getLength();i++){
            double sum=v1.getCoordinate(i)+v2.getCoordinate(i);
            result.setCoordinate(i,sum);
        }
        return result;
    }

    public static double scalarProduct(Vector v1, Vector v2){
        if (v1.getLength() != v2.getLength()) {
            throw new IllegalArgumentException("Векторы должны быть одинаковой длины");
        }
        double product = 0.0;
        for (int i = 0; i < v1.getLength(); i++) {
            product += v1.getCoordinate(i) * v2.getCoordinate(i);
        }
        return product;
    }

    public String toString() {
        return Arrays.toString(coordinates);
    }

}