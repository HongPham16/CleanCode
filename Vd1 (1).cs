import java.util.*;

class Student {
    private String id;
    private String name;
    private int age;
    private double gpa;

    public Student(String id, String name, int age, double gpa) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.gpa = gpa;
    }

    public String getId() { return id; }
    public String getName() { return name; }
    public int getAge() { return age; }
    public double getGpa() { return gpa; }

    public void update(String name, int age, double gpa) {
        this.name = name;
        this.age = age;
        this.gpa = gpa;
    }

    @Override
    public String toString() {
        return String.format("ID:%s | Name:%s | Age:%d | GPA:%.2f", id, name, age, gpa);
    }
}

class StudentManager {
    private List<Student> students = new ArrayList<>();

    public void addStudent(Student s) {
        students.add(s);
    }

    public void removeStudent(String id) {
        students.removeIf(s -> s.getId().equals(id));
    }

    public void updateStudent(String id, String name, int age, double gpa) {
        for (Student s : students) {
            if (s.getId().equals(id)) {
                s.update(name, age, gpa);
            }
        }
    }

    public void displayAll() {
        students.forEach(System.out::println);
    }

    public void findByName(String name) {
        students.stream()
                .filter(s -> s.getName().equalsIgnoreCase(name))
                .forEach(System.out::println);
    }

    public void findHighGPA(double threshold) {
        students.stream()
                .filter(s -> s.getGpa() > threshold)
                .forEach(System.out::println);
    }

    public void sortByName() {
        students.sort(Comparator.comparing(Student::getName));
    }

    public void sortByGpaDesc() {
        students.sort(Comparator.comparing(Student::getGpa).reversed());
    }
}

public class CleanSchoolProgram {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        StudentManager sm = new StudentManager();

        int choice;
        do {
            System.out.println("--- QUAN LY SINH VIEN ---");
            System.out.println("1. Them SV");
            System.out.println("2. Xoa SV");
            System.out.println("3. Cap nhat SV");
            System.out.println("4. Hien thi tat ca SV");
            System.out.println("5. Tim SV theo ten");
            System.out.println("6. Tim SV GPA > 8");
            System.out.println("7. Sap xep theo ten");
            System.out.println("8. Sap xep theo GPA");
            System.out.println("9. Thoat");
            System.out.print("Nhap lua chon: ");
            choice = sc.nextInt(); sc.nextLine();

            switch (choice) {
                case 1 -> {
                    System.out.print("Nhap id: "); String id = sc.nextLine();
                    System.out.print("Nhap ten: "); String name = sc.nextLine();
                    System.out.print("Nhap tuoi: "); int age = sc.nextInt();
                    System.out.print("Nhap GPA: "); double gpa = sc.nextDouble(); sc.nextLine();
                    sm.addStudent(new Student(id, name, age, gpa));
                }
                case 2 -> {
                    System.out.print("Nhap id can xoa: ");
                    sm.removeStudent(sc.nextLine());
                }
                case 3 -> {
                    System.out.print("Nhap id can cap nhat: "); String id = sc.nextLine();
                    System.out.print("Nhap ten moi: "); String name = sc.nextLine();
                    System.out.print("Nhap tuoi moi: "); int age = sc.nextInt();
                    System.out.print("Nhap GPA moi: "); double gpa = sc.nextDouble(); sc.nextLine();
                    sm.updateStudent(id, name, age, gpa);
                }
                case 4 -> sm.displayAll();
                case 5 -> {
                    System.out.print("Nhap ten: "); sm.findByName(sc.nextLine());
                }
                case 6 -> sm.findHighGPA(8.0);
                case 7 -> sm.sortByName();
                case 8 -> sm.sortByGpaDesc();
            }
        } while (choice != 9);
    }
}
